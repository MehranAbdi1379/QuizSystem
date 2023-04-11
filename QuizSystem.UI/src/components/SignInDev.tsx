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

    let JWTToken =
      "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlN0dWRlbnQiLCJleHAiOjE2ODEyNDM0NTIsImlzcyI6IlF1aXpTeXN0ZW0uQVBJIn0.ggIfYDKqIc3M9vTuNLl0207kOgOwNx9iHYSgWW-fU_8";
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
