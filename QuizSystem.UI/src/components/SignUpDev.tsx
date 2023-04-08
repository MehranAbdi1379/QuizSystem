import React, { useState } from "react";
import Button from "./Button";
import axios from "axios";
import Label from "./Label";
import RadioButtonGroup from "./RadioButtonGroup";
import Input from "./Input";

const SignUpDev = () => {
  const [radioChoice, setRadioChoice] = useState("");
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [nationalCode, setNationalCode] = useState("");
  const [birthDate, setBirthDate] = useState(new Date());
  const [password, setPassword] = useState("");

  function onSubmit() {
    axios.post("");
  }

  return (
    <div>
      <form>
        <Label>First Name: </Label>
        <Input required type="text"></Input>
        <br></br>
        <Label>Last Name: </Label>
        <Input required type="text"></Input>
        <br></br>
        <Label>National Code: </Label>
        <Input required type="text"></Input>
        <br></br>
        <Label>Birth Date: </Label>
        <Input required type="date"></Input>
        <br></br>
        <Label>Password: </Label>
        <Input required type="password"></Input>
        <br></br>
        <RadioButtonGroup
          onClick={setRadioChoice}
          groupName="student-professor"
          buttonNames={["Student", "Professor"]}
        ></RadioButtonGroup>
        <Button name="Sign Up" onClick={onSubmit}></Button>
      </form>
    </div>
  );
};

export default SignUpDev;
