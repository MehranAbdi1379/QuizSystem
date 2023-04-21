import React, { useState } from "react";
import Button from "./Button";
import axios from "axios";
import Label from "./Label";
import Input from "./Input";
import RadioButtonGroup from "./RadioButtonGroup";

interface Props {
  accessToken: string;
  setAccessToken: (token: string) => void;
}

const SignInDev = ({ setAccessToken, accessToken }: Props) => {
  const [nationalCode, setNationalCode] = useState("");
  const [password, setPassword] = useState("");

  function onSearch() {
    const data = {
      role: "",
      firstName: "",
      lastName: "",
    };

    axios
      .post("https://localhost:7031/api/User/Search", data, {
        headers: {
          authorization: `Bearer ${accessToken}`,
        },
      })
      .then((res) => {
        console.log("profile is:", res.data);
      })
      .catch((error) => console.log(error));

    console.log(accessToken);
    console.log("this is just a message");
  }

  function onSubmit() {
    const user = {
      nationalCode,
      password,
    };
    axios
      .post("https://localhost:7031/api/User/Sign-In", user)
      .then((response) => setAccessToken(response.data.token));
  }

  return (
    <div>
      <Label>National Code: </Label>
      <Input required type="text" onChange={setNationalCode}></Input>
      <br></br>
      <Label>Password: </Label>
      <Input onChange={setPassword} required type="password"></Input>
      <br></br>
      <Button name="Sign in" onClick={onSubmit}></Button>
      <Button name="Search" onClick={onSearch}></Button>
    </div>
  );
};

export default SignInDev;
