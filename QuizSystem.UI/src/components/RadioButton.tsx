import React from "react";

interface Props {
  name: string;
  group: string;
  onClick: (name: string) => void;
}

const RadioButton = ({ name, group, onClick }: Props) => {
  return (
    <>
      <input
        type="radio"
        name={group}
        id={name}
        value={name}
        onChange={() => {
          onClick(name);
        }}
      ></input>
      <label id={name}>{name}</label>
    </>
  );
};

export default RadioButton;
