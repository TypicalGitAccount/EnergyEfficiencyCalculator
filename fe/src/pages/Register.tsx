import {
  Avatar,
  Box,
  Button,
  Container,
  CssBaseline,
  Grid,
  TextField,
  Typography,
} from "@mui/material";
import { LockOutlined } from "@mui/icons-material";
import { useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import useAuthContext from "../common/hooks/useAuthContext";
import { motion } from "framer-motion";
import { Helmet } from "react-helmet";

const Register = () => {
  const { user, jwtTokens, registerUser } = useAuthContext();
  const navigate = useNavigate();
  useEffect(() => {
    if (user && jwtTokens) {
      navigate("/");
    }
  }, [user, jwtTokens]);

  return (
    <motion.div
      initial={{ width: 0 }}
      animate={{ width: "100%" }}
      exit={{ x: window.innerWidth, transition: { duration: 0.01 } }}
    >
      <Helmet>
        <title>{"Реєстрація"}</title>
      </Helmet>

      <Container maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            mt: 20,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: "primary.light" }}>
            <LockOutlined />
          </Avatar>
          <Typography variant="h5">Реєстрація</Typography>
          <form onSubmit={registerUser}>
            <Box sx={{ mt: 3 }}>
              <Grid container spacing={2}>
                <Grid item xs={12}>
                  <TextField
                    name="username"
                    required
                    fullWidth
                    id="username"
                    label="Логін"
                    autoFocus
                  />
                </Grid>

                <Grid item xs={12}>
                  <TextField
                    required
                    fullWidth
                    id="email"
                    label="Електронна адреса"
                    name="email"
                  />
                </Grid>
                <Grid item xs={12}>
                  <TextField
                    required
                    fullWidth
                    name="password"
                    label="Пароль"
                    type="password"
                    id="password"
                  />
                </Grid>
              </Grid>
              <Button
                fullWidth
                variant="contained"
                sx={{ mt: 3, mb: 2 }}
                type="submit"
              >
                Реєстрація
              </Button>
              <Grid container justifyContent="flex-end">
                <Grid item>
                  <Link to="/login">Вже маєте акаунт? Вхід</Link>
                </Grid>
              </Grid>
            </Box>
          </form>
        </Box>
      </Container>
    </motion.div>
  );
};

export default Register;
