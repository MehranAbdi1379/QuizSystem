import React from "react";
import RadioButton from "./RadioButton";

interface Props {
  groupName: string;
  buttonNames: string[];
  onClick: (name: string) => void;
}

const RadioButtonGroup = ({ groupName, buttonNames, onClick }: Props) => {
  return (
    <>
      {buttonNames.map((buttonName) => (
        <RadioButton
          name={buttonName}
          group={groupName}
          onClick={onClick}
        ></RadioButton>
      ))}
    </>
  );
};

export default RadioButtonGroup;
