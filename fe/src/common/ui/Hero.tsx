import { alpha } from "@mui/material";
import Box from "@mui/material/Box";
import Container from "@mui/material/Container";
import { relative } from "path";

export default function Hero() {
  return (
    <Box
      id="hero"
      sx={(theme) => ({
        width: "100%",
        backgroundImage: "linear-gradient(0deg, #ffa500, #FFF)",
        backgroundSize: "100% 20%",
        backgroundRepeat: "no-repeat",
        height: "50px",
        top: "200px",
        position: "absolute",
      })}
    >
      <Container
        sx={{
          pt: { xs: 14, sm: 20 },
          pb: { xs: 8, sm: 12 },
          height: "5px",
        }}
      ></Container>
    </Box>
  );
}
