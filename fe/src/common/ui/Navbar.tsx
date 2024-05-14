import { Container, Nav, Navbar as NavbarBs } from "react-bootstrap";
import { NavLink } from "react-router-dom";
import React, { useState } from "react";
import useAuthContext from "../hooks/useAuthContext";
import Confirmation from "./Confirmation";

export const Navbar: React.FC = () => {
  const { user, jwtTokens, logoutUser } = useAuthContext();
  const [confirmation, setConfirmation] = useState(false);

  return (
    <NavbarBs
      sticky="top"
      className="bg-white shadow-sm navbar-nav mx-auto"
      style={{
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        textAlign: "center",
        alignSelf: "center",
        height: "80px",
      }}
    >
      <Container style={{ textAlign: "center", alignContent: "center" }}>
        <div className="container justify-content-center ">
          <Nav>
            <Nav.Link to="/" as={NavLink} disabled={confirmation}>
              Головна
            </Nav.Link>
            <Nav.Link to="/advices" as={NavLink} disabled={confirmation}>
              Рекомендації
            </Nav.Link>
            <Nav.Link to="/efficiency" as={NavLink} disabled={confirmation}>
              Калькулятор енергоефективності
            </Nav.Link>
            {user && jwtTokens ? (
              <>
                <Nav.Link to="/profile" as={NavLink} disabled={confirmation}>
                  Профіль
                </Nav.Link>
                <Nav.Link
                  onClick={(event) => {
                    event.preventDefault();
                    setConfirmation(true);
                  }}
                  to="/login"
                  as={NavLink}
                  disabled={confirmation}
                >
                  Вийти
                </Nav.Link>
                {confirmation && (
                  <Confirmation
                    title={`Вийти з профіля ${user.name}?`}
                    declineContent={"Ні"}
                    confirmContent={"Так"}
                    onDecline={() => setConfirmation(false)}
                    onConfirm={() => {
                      logoutUser();
                      setConfirmation(false);
                    }}
                  />
                )}
              </>
            ) : (
              <>
                <Nav.Link to="/login" as={NavLink}>
                  Вхід
                </Nav.Link>
                <Nav.Link to="/register" as={NavLink}>
                  Реєстрація
                </Nav.Link>
              </>
            )}
          </Nav>
        </div>
      </Container>
    </NavbarBs>
  );
};
