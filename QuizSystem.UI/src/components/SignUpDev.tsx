import React, { useState } from "react";
import Button from "./Button";
import axios from "axios";
import Label from "./Label";
import RadioButtonGroup from "./RadioButtonGroup";
import Input from "./Input";
import Form from "./Form";

const SignUpDev = () => {
  const [radioChoice, setRadioChoice] = useState("");
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [nationalCode, setNationalCode] = useState("");
  const [birthDate, setBirthDate] = useState(new Date());
  const [password, setPassword] = useState("");

  function onSubmit() {
    const user = {
      radioChoice,
      firstName,
      lastName,
      nationalCode,
      birthDate,
      password,
    };
    console.log(user);
    console.log(radioChoice);
    if (radioChoice === "Student")
      axios
        .post("https://localhost:7031/api/Students/Create", user)
        .then((response) => console.log(response.data));
    if (radioChoice === "Professor")
      axios
        .post("https://localhost:7031/api/Professor/Create", user)
        .then((response) => console.log(response));
  }

  return (
    <div>
      <form>
        <Label>First Name: </Label>
        <Input onChange={setFirstName} required type="text"></Input>
        <br></br>
        <Label>Last Name: </Label>
        <Input onChange={setLastName} required type="text"></Input>
        <br></br>
        <Label>National Code: </Label>
        <Input onChange={setNationalCode} required type="number"></Input>
        <br></br>
        <Label>Birth Date: </Label>
        <Input onChange={setBirthDate} required type="date"></Input>
        <br></br>
        <Label>Password: </Label>
        <Input onChange={setPassword} required type="password"></Input>
        <br></br>
        <RadioButtonGroup
          onClick={setRadioChoice}
          groupName="User"
          buttonNames={["Student", "Professor"]}
        ></RadioButtonGroup>
        <Button name="Sign Up" onClick={onSubmit}></Button>
      </form>
    </div>
  );
};

export default SignUpDev;
