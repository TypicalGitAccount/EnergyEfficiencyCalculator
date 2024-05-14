import React, { useState } from "react";
import { toast } from "react-toastify";
import CreateIcon from "@mui/icons-material/Create";
import {
  Avatar,
  Box,
  CssBaseline,
  Input,
  TextField,
  Typography,
  Button,
} from "@mui/material";
import { Container, Modal } from "react-bootstrap";
import EditUserForm from "./EditUserForm";
import useAuthContext from "../hooks/useAuthContext";
import { updateUser } from "../api";
import { User, UserUpdateDto } from "../interfaces";

interface UserDetailProps {
  userObj: User;
}

const UserDetail = ({ userObj }: UserDetailProps) => {
  const [isEditing, setIsEditing] = useState(false);
  const { user, jwtTokens, logoutUser, refreshToken, changePassword } =
    useAuthContext();
  const [oldPassword, setOldPassword] = useState<string | undefined>();
  const [newPassword, setNewPassword] = useState<string | undefined>();

  const handleEditSave = async (updatedUser: UserUpdateDto) => {
    await updateUser(jwtTokens!.accessToken, updatedUser);
    setIsEditing(false);
    refreshToken(jwtTokens!);
  };

  const handlePasswordChangeSubmit = async (
    event: React.FormEvent<HTMLFormElement>
  ) => {
    event.preventDefault();

    if (oldPassword === undefined) {
      toast.error("Старий пароль ввести обов'язково!");
      return;
    }

    if (newPassword === undefined) {
      toast.error("Новий пароль ввести обов'язково!");
      return;
    }

    if (await changePassword(oldPassword, newPassword)) {
      toast.success("Пароль змінено успішно!");
      setOldPassword("");
      setNewPassword("");
    }
  };

  return (
    <Container>
      {isEditing && (
        <Modal width="500px" height="auto" onClose={() => setIsEditing(false)}>
          <EditUserForm user={userObj} onSave={handleEditSave} />
        </Modal>
      )}

      <Box sx={{ mt: 1 }}>
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
            <CreateIcon />
          </Avatar>
          <Typography variant="h5">Профіль {userObj.name}</Typography>

          <Typography mt={2} variant="body1">
            {userObj.email
              ? `Електронна адреса - ${userObj.email}`
              : "Немає електронної адреси"}
          </Typography>
        </Box>

        <CssBaseline />
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Typography sx={{ mt: 2 }} variant="h5">
            Змінити пароль
          </Typography>
          <form onSubmit={handlePasswordChangeSubmit}>
            <Box
              sx={{
                display: "flex",
                flexDirection: "column",
                alignItems: "center",
              }}
            >
              <TextField
                sx={{ mt: 2 }}
                type="password"
                label="Старий пароль"
                value={oldPassword}
                id="oldpassword"
                name="oldpassword"
                onChange={(e) => setOldPassword(e.target.value)}
              />
              <TextField
                sx={{ mt: 2 }}
                type="password"
                label="Новий пароль"
                value={newPassword}
                id="newpassword"
                name="newpassword"
                onChange={(e) => setNewPassword(e.target.value)}
              />

              <Button sx={{ mt: 3 }} variant="contained" type="submit">
                Змінити
              </Button>
            </Box>
          </form>
        </Box>
      </Box>
    </Container>
  );
};

export default UserDetail;
