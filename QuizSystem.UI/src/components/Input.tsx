import React from "react";

interface Props {
  type: string;
  required: boolean;
  onChange: (value: any) => void;
}

const Input = ({ type, required, onChange }: Props) => {
  return (
    <input
      required={required}
      type={type}
      onChange={(e) => onChange(e.target.value)}
    ></input>
  );
};

export default Input;
