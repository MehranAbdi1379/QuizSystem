import React, { useState } from "react";
import SignDev from "./SignDev";

const Parent = () => {
  const [accessToken, setAccessToken] = useState("");
  return (
    <div>
      <SignDev
        accessToken={accessToken}
        setAccessToken={setAccessToken}
      ></SignDev>
      <button onClick={() => console.log(accessToken)}>Click to log</button>
    </div>
  );
};

export default Parent;
