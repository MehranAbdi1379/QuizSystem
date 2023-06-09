import React, { useEffect, useState } from "react";
import { Box, Text } from "@chakra-ui/react";
import UserServices from "../../services/UserServices";

interface Props {
  id: string;
}

const UserFirstNameLastNameDisplay = ({ id }: Props) => {
  const { GetNameById } = new UserServices();
  const [user, setUser] = useState<{
    firstName: string;
    lastName: string;
  }>();
  useEffect(() => {
    GetNameById(id, setUser);
  }, [id]);
  return (
    <Box>
      {user?.firstName} {user?.lastName}
    </Box>
  );
};

export default UserFirstNameLastNameDisplay;
