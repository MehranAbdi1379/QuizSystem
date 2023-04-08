import React, { ReactNode } from "react";

interface Props {
  children: ReactNode;
}

const Form = ({ children }: Props) => {
  return <form>{children}</form>;
};

export default Form;
