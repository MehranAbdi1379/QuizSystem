import React, { useState } from "react";
import Button from "./Button";
import axios from "axios";
import Label from "./Label";
import Input from "./Input";
import RadioButtonGroup from "./RadioButtonGroup";

const SignInDev = () => {
  const [nationalCode, setNationalCode] = useState("");
  const [password, setPassword] = useState("");
  const [type, settype] = useState("");

  function onSubmit() {
    const user = {
      type,
      nationalCode,
      password,
    };
    axios
      .post("https://localhost:7031/api/User/Sign-In", user)
      .then((response) => console.log(response.data));
  }

  return (
    <div>
      <Label>National Code: </Label>
      <Input required type="text" onChange={setNationalCode}></Input>
      <br></br>
      <Label>Password: </Label>
      <Input onChange={setPassword} required type="password"></Input>
      <br></br>
      <RadioButtonGroup
        buttonNames={["Student", "Professor", "Admin"]}
        groupName="User"
        onClick={settype}
      ></RadioButtonGroup>
      <Button name="Sign in" onClick={onSubmit}></Button>
    </div>
  );
};

export default SignInDev;
