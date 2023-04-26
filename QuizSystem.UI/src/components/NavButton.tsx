import { Button } from "@chakra-ui/react";
import React from "react";

interface Props {
  name: string;
}

const NavButton = ({ name }: Props) => {
  return <Button>{name}</Button>;
};

export default NavButton;
