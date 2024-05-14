import React, { useState } from "react";
import { AdviceDto, BuildingTypesToLabels } from "../../interfaces";
import ViewedAdvice from "./ViewedAdvice";
import {
  Card,
  CardContent,
  CardHeader,
  IconButton,
  Tooltip,
  Typography,
} from "@mui/material";
import { DeleteOutlined, EditOutlined } from "@mui/icons-material";
import Confirmation from "../Confirmation";

interface CardProps {
  onEdit: () => void;
  onView: (state: boolean) => void;
  isAdmin: boolean;
  onDeleteAdvice: () => void;
  setViewing: (val: boolean) => void;
  confirmation: boolean;
  setConfirmation: (val: boolean) => void;
  item: AdviceDto;
  isViewed: boolean;
}

const CardComponent: React.FC<CardProps> = (props) => {
  const {
    item,
    confirmation,
    setConfirmation,
    onEdit,
    onDeleteAdvice,
    onView,
    isAdmin,
    setViewing,
    isViewed,
  } = props;

  return (
    <>
      <Card
        elevation={1}
        sx={
          !isViewed
            ? { maxWidth: 250, maxHeight: 300 }
            : { maxWidth: 800, maxHeight: 600, overflowY: "scroll" }
        }
      >
        <CardHeader
          action={
            <>
              {isAdmin && !isViewed && (
                <>
                  <Tooltip title="Видалити">
                    <IconButton
                      onClick={() => {
                        onView(false);
                        setConfirmation(true);
                      }}
                    >
                      <DeleteOutlined />
                    </IconButton>
                  </Tooltip>
                  {confirmation && (
                    <Confirmation
                      title={
                        <>
                          <h1>Видалити</h1>
                          <h1>{`рекомендацію ${item.title} ?`}</h1>
                        </>
                      }
                      declineContent={<>Ні</>}
                      confirmContent={<>Так</>}
                      onDecline={() => {
                        onView(true);
                        setConfirmation(false);
                      }}
                      onConfirm={onDeleteAdvice}
                    />
                  )}
                  <Tooltip title="Редагувати">
                    <IconButton onClick={onEdit}>
                      <EditOutlined />
                    </IconButton>
                  </Tooltip>
                </>
              )}
            </>
          }
          sx={{
            display: "flex",
            border: `2px solid #F5F5F5`,
            "&:hover": { border: `2px solid #E0E0E0` },
            maxWidth: isViewed ? 800 : 500,
          }}
          subheader={
            isViewed && (
              <>
                {`Цінова категорія: ${item.minPrice} грн ~ ${item.maxPrice} грн`}
                <br />
                {`Тип будівлі: ${BuildingTypesToLabels.get(item.buildingType)}`}
              </>
            )
          }
        />
        <CardContent
          sx={
            !isViewed
              ? {
                  cursor: "pointer",
                  backgroundColor: "grey.100",
                  "&:hover": { backgroundColor: "grey.300" },
                }
              : undefined
          }
          onClick={() => {
            setViewing(true);
            onView(false);
          }}
        >
          <h4>{item.title}</h4>
          <Typography
            variant="body1"
            color="textSecondary"
            sx={
              !isViewed
                ? {
                    wordWrap: "break-word",
                    overflow: "hidden",
                    whiteSpace: "nowrap",
                    textOverflow: "ellipsis",
                  }
                : undefined
            }
          >
            {item.recommendationText}
          </Typography>
        </CardContent>
      </Card>
    </>
  );
};

interface AdviceCardProps {
  token: string;
  item: AdviceDto;
  onEdit: () => void;
  onView: (state: boolean) => void;
  isAdmin: boolean;
  onDeleteAdvice: () => void;
}

const AdviceCard: React.FC<AdviceCardProps> = ({
  item,
  onDeleteAdvice,
  onEdit,
  isAdmin,
  onView,
}) => {
  const [confirmation, setConfirmation] = useState(false);
  const [viewing, setViewing] = useState(false);

  return (
    <>
      {viewing ? (
        <ViewedAdvice
          onCloseView={() => {
            setViewing(false);
            onView(true);
          }}
        >
          <CardComponent
            onEdit={onEdit}
            onView={onView}
            isAdmin={isAdmin}
            onDeleteAdvice={onDeleteAdvice}
            setViewing={setViewing}
            confirmation={confirmation}
            setConfirmation={setConfirmation}
            item={item}
            isViewed={true}
          />
        </ViewedAdvice>
      ) : (
        <CardComponent
          onEdit={onEdit}
          onView={onView}
          isAdmin={isAdmin}
          onDeleteAdvice={onDeleteAdvice}
          setViewing={setViewing}
          confirmation={confirmation}
          setConfirmation={setConfirmation}
          item={item}
          isViewed={false}
        />
      )}
    </>
  );
};

export default AdviceCard;
