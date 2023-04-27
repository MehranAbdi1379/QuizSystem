import { Button } from "@chakra-ui/react";
import React from "react";
import { NavLink } from "react-router-dom";

interface Props {
  name: string;
  to: string;
  onClick?: () => void;
}

const NavButton = ({ name, to, onClick }: Props) => {
  return (
    <NavLink to={to}>
      <Button onClick={onClick}>{name}</Button>
    </NavLink>
  );
};

export default NavButton;
