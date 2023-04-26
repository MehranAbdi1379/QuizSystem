import { Button } from "@chakra-ui/react";
import React from "react";
import { NavLink } from "react-router-dom";

interface Props {
  name: string;
  to: string;
}

const NavButton = ({ name, to }: Props) => {
  return (
    <NavLink to={to}>
      <Button>{name}</Button>
    </NavLink>
  );
};

export default NavButton;
