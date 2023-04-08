import React from "react";

interface Props {
  type: string;
  required: boolean;
}

const Input = ({ type, required }: Props) => {
  return <input required={required} type={type}></input>;
};

export default Input;
