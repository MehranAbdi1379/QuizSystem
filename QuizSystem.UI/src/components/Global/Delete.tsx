import { Heading, Button, Box } from "@chakra-ui/react";
import React from "react";

interface Props {
  onClick: () => void;
  setDeleteOn: (value: boolean) => void;
}

const DeleteYesOrNo = ({ onClick, setDeleteOn }: Props) => {
  return (
    <Box
      position={"fixed"}
      paddingLeft={"45%"}
      paddingTop={"20%"}
      left={0}
      top={0}
      right={0}
      width={"100vw"}
      height={"100vh"}
      bg={"blackAlpha.700"}
      zIndex={0}
    >
      <Box margin={"auto"}>
        <Heading marginBottom={3} fontSize={25} color={"white"}>
          Are you sure?{" "}
        </Heading>
        <Button
          colorScheme="red"
          fontSize={20}
          marginRight={3}
          p={7}
          paddingLeft={10}
          paddingRight={10}
          onClick={() => onClick()}
        >
          Yes
        </Button>
        <Button
          colorScheme="green"
          fontSize={20}
          marginRight={3}
          p={7}
          paddingLeft={10}
          paddingRight={10}
          onClick={() => setDeleteOn(false)}
        >
          No
        </Button>
      </Box>
    </Box>
  );
};

export default DeleteYesOrNo;
