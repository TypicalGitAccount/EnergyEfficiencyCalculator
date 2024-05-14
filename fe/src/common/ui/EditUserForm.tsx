import React, { useState } from "react";
import { Label, LockOutlined } from "@mui/icons-material";
import {
    Avatar,
    Box,
    Button,
    Container,
    CssBaseline,
    TextField,
    Typography,
} from "@mui/material";
import { User } from "../interfaces";

export interface EditUserFormProps {
    user: User;
    onSave: (user: User) => void;
}

const EditUserForm = ({ user, onSave }: EditUserFormProps) => {
    const [name, setName] = useState(user.name);
    const [phone, setPhone] = useState(user.phone);
    const [telegram, setTelegram] = useState(user.telegram);

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        await onSave({ ...user, name, phone, telegram });
    };

    return (
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
                <Typography variant="h5">Edit info</Typography>
                <form onSubmit={handleSubmit}>
                    <Box sx={{ mt: 1 }}>
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            id="name"
                            label="Name"
                            value={name}
                            type="text"
                            autoFocus
                            onChange={(e) => setName(e.target.value)}
                        />
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            id="phone"
                            label="Phone"
                            value={phone}
                            type="phone"
                            onChange={(e) => setPhone(e.target.value)}
                        />
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            id="telegram"
                            label="Telegram"
                            type="text"
                            placeholder="nickname without @"
                            value={telegram}
                            onChange={(e) => setTelegram(e.target.value)}
                        />

                        <Button
                            fullWidth
                            variant="contained"
                            sx={{ mt: 3, mb: 2 }}
                            type="submit"
                        >
                            Save changes
                        </Button>
                    </Box>
                </form>
            </Box>
        </Container>
    );
};

export default EditUserForm;
