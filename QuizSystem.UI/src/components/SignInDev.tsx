import React from "react";
import Button from "./Button";
import axios from "axios";
import Label from "./Label";

const SignInDev = () => {
  function onSubmit() {}

  return (
    <div>
      <Label>National Code: </Label>
      <input id="nationalCode"></input>
      <br></br>
      <Label>Password: </Label>
      <input id="password"></input>
      <br></br>
      <Button name="Sign in" onClick={onSubmit}></Button>
    </div>
  );
};

export default SignInDev;
