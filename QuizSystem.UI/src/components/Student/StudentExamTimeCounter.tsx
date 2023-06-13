import React, { useEffect, useState } from "react";
import ExamStudentService from "../../services/ExamStudentService";
import { Heading } from "@chakra-ui/react";

interface Props {
  examId: string;
  endTime: Date;
}

const StudentExamTimeCounter = ({ examId, endTime }: Props) => {
  const [minutes, setMinutes] = useState<number>(0);
  const [second, setSeconds] = useState<number>(0);
  const [finished, setFinished] = useState();
  const [error, setError] = useState();

  const { Finished } = new ExamStudentService();

  useEffect(() => {
    Finished(examId, setFinished, setError);
    if (!finished) {
      Finished(examId, setFinished, setError);
      const endtime = endTime.toString().slice(11, 19);
      const nowHours = new Date().getHours();
      const nowMinutes = new Date().getMinutes();
      const nowSeconds = new Date().getSeconds();
      setSeconds(
        (parseInt(endtime?.slice(0, 2) ? endtime?.slice(0, 2) : "") * 3600 +
          parseInt(endtime?.slice(3, 5) ? endtime?.slice(3, 5) : "") * 60 +
          parseInt(endtime?.slice(6, 8) ? endtime?.slice(6, 8) : "") -
          (nowHours * 3600 + nowMinutes * 60 + nowSeconds)) %
          60
      );
      setMinutes(
        (parseInt(endtime?.slice(0, 2) ? endtime?.slice(0, 2) : "") * 3600 +
          parseInt(endtime?.slice(3, 5) ? endtime?.slice(3, 5) : "") * 60 +
          parseInt(endtime?.slice(6, 8) ? endtime?.slice(6, 8) : "") -
          (nowHours * 3600 + nowMinutes * 60 + nowSeconds) -
          ((parseInt(endtime?.slice(0, 2) ? endtime?.slice(0, 2) : "") * 3600 +
            parseInt(endtime?.slice(3, 5) ? endtime?.slice(3, 5) : "") * 60 +
            parseInt(endtime?.slice(6, 8) ? endtime?.slice(6, 8) : "") -
            (nowHours * 3600 + nowMinutes * 60 + nowSeconds)) %
            60)) /
          60
      );
    }

    const secondTimer = setInterval(() => {
      if (!finished) {
        Finished(examId, setFinished, setError);
        const endtime = endTime.toString().slice(11, 19);
        const nowHours = new Date().getHours();
        const nowMinutes = new Date().getMinutes();
        const nowSeconds = new Date().getSeconds();
        setSeconds(
          (parseInt(endtime?.slice(0, 2) ? endtime?.slice(0, 2) : "") * 3600 +
            parseInt(endtime?.slice(3, 5) ? endtime?.slice(3, 5) : "") * 60 +
            parseInt(endtime?.slice(6, 8) ? endtime?.slice(6, 8) : "") -
            (nowHours * 3600 + nowMinutes * 60 + nowSeconds)) %
            60
        );
        setMinutes(
          (parseInt(endtime?.slice(0, 2) ? endtime?.slice(0, 2) : "") * 3600 +
            parseInt(endtime?.slice(3, 5) ? endtime?.slice(3, 5) : "") * 60 +
            parseInt(endtime?.slice(6, 8) ? endtime?.slice(6, 8) : "") -
            (nowHours * 3600 + nowMinutes * 60 + nowSeconds) -
            ((parseInt(endtime?.slice(0, 2) ? endtime?.slice(0, 2) : "") *
              3600 +
              parseInt(endtime?.slice(3, 5) ? endtime?.slice(3, 5) : "") * 60 +
              parseInt(endtime?.slice(6, 8) ? endtime?.slice(6, 8) : "") -
              (nowHours * 3600 + nowMinutes * 60 + nowSeconds)) %
              60)) /
            60
        );
      }
    }, 1000);
    return () => clearInterval(secondTimer);
  });
  return (
    <>
      {!finished && (minutes || minutes == 0) && (second || second == 0) && (
        <Heading color={"green.300"} paddingRight={5} fontSize={20}>
          Time left: {minutes}:{second}
        </Heading>
      )}
      {finished && (
        <Heading color={"red.400"} paddingRight={5} fontSize={20}>
          Exam is finished
        </Heading>
      )}
    </>
  );
};

export default StudentExamTimeCounter;
