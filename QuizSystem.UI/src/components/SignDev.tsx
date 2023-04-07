import React, { useState } from "react";
import SignButton from "./Button";
import SignUpDev from "./SignUpDev";
import SignInDev from "./SignInDev";

const SignDev = () => {
  const [signUpOrIn, setSignUpOrIn] = useState(0);

  function onSignUp() {
    setSignUpOrIn(1);
  }

  function onSignIn() {
    setSignUpOrIn(2);
  }

  return (
    <div>
      {signUpOrIn === 0 && (
        <SignButton name="Sign In" onClick={onSignIn}></SignButton>
      )}
      {signUpOrIn === 0 && (
        <SignButton name="Sign Up" onClick={onSignUp}></SignButton>
      )}

      {signUpOrIn === 1 && <SignUpDev></SignUpDev>}

      {signUpOrIn === 2 && <SignInDev></SignInDev>}
    </div>
  );
};

export default SignDev;
