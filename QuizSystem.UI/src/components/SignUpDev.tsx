import React, { useState } from "react";
import Button from "./Button";
import axios from "axios";
import Label from "./Label";
import RadioButtonGroup from "./RadioButtonGroup";

const SignUpDev = () => {
  const [radioChoice, setRadioChoice] = useState("student");

  function sendDataToParent(name: string) {
    setRadioChoice(name);
  }

  function onSubmit() {
    axios.post("");
  }

  return (
    <div>
      <Label>First Name: </Label>
      <input id="firstName"></input>
      <br></br>
      <Label>Last Name: </Label>
      <input id="lastName"></input>
      <br></br>
      <Label>National Code: </Label>
      <input id="nationalCode"></input>
      <br></br>
      <Label>Birth Date: </Label>
      <input id="birthDate" type="date"></input>
      <br></br>
      <Label>Password: </Label>
      <input id="password" type="password"></input>
      <br></br>
      <RadioButtonGroup
        onClick={sendDataToParent}
        groupName="student-professor"
        buttonNames={["Student", "Professor"]}
      ></RadioButtonGroup>
      <Button name="Sign Up" onClick={onSubmit}></Button>
    </div>
  );
};

export default SignUpDev;
