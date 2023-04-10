import React, { useState } from "react";
import Button from "./Button";
import axios from "axios";
import Label from "./Label";
import RadioButtonGroup from "./RadioButtonGroup";
import Input from "./Input";
import Form from "./Form";

const SignUpDev = () => {
  const [role, setrole] = useState("");
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [nationalCode, setNationalCode] = useState("");
  const [birthDate, setBirthDate] = useState(new Date());
  const [password, setPassword] = useState("");

  function onSubmit() {
    const user = {
      role,
      firstName,
      lastName,
      nationalCode,
      birthDate,
      password,
    };
    console.log(user);
    console.log(role);

    axios
      .post("https://localhost:7031/api/User/Sign-Up", user)
      .then((response) => console.log(response.data));
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
          onClick={setrole}
          groupName="User"
          buttonNames={["Student", "Professor"]}
        ></RadioButtonGroup>
        <Button name="Sign Up" onClick={onSubmit}></Button>
      </form>
    </div>
  );
};

export default SignUpDev;
