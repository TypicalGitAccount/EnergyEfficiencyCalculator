import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Helmet } from "react-helmet";
import useAuthContext from "../common/hooks/useAuthContext";
import {
  Container,
  Grid,
  Box,
  Dialog,
  CircularProgress,
  Fab,
} from "@mui/material";
import EditAdvice from "../common/ui/Advices/EditAdvice";
import {
  AdviceCriteriaDto,
  AdviceDto,
  BuildingTypes,
} from "../common/interfaces";
import { deleteAdvice, getAdvices, getAdvicesFor } from "../common/api";
import "react-confirm-alert/src/react-confirm-alert.css";
import { motion } from "framer-motion";
import AdviceCard from "../common/ui/Advices/AdviceCard";
import { Add } from "@mui/icons-material";
import Filters from "../common/ui/Advices/Filters";

const handleDeleteAdvice = async (token: string, id: string) => {
  const data = await deleteAdvice(token, id);
  if (data) {
    window.location.reload();
  }
};

const Advices: React.FC = (props) => {
  const navigate = useNavigate();
  const { user, jwtTokens } = useAuthContext();
  const idAdmin = user?.role?.includes("Admin");
  const [loading, setLoading] = useState(false);
  const { buildingFilterFromRoute } = useParams();
  const buildingFilter = parseInt(buildingFilterFromRoute ?? "nan");
  const [filters, setFilters] = useState<AdviceCriteriaDto>({
    minPrice: 0,
    maxPrice: 50000000,
    buildingType: isNaN(buildingFilter)
      ? BuildingTypes.Any
      : (buildingFilter as BuildingTypes),
  });
  const [addButtonVisible, setAddButtonVisible] = useState(true);
  const [editForm, setEditForm] = useState(false);
  const [editedItem, setEditedItem] = useState<AdviceDto | null>(null);
  const [data, setData] = useState<AdviceDto[] | null>(null);

  useEffect(() => {
    async function fetchData() {
      setLoading(true);
      const data =
        buildingFilter === BuildingTypes.Any
          ? await getAdvices(jwtTokens!.accessToken)
          : await getAdvicesFor(jwtTokens!.accessToken, filters);
      setData(data);
      setLoading(false);
    }

    if (!user || !jwtTokens) {
      navigate("/login");
    } else {
      fetchData();
    }
  }, [user, jwtTokens]);

  const searchAdvices = async () => {
    setLoading(true);
    const data = await getAdvicesFor(jwtTokens!.accessToken, filters);
    setData(data);
    setLoading(false);
  };

  return (
    <motion.div
      initial={{ width: 0 }}
      animate={{ width: "100%" }}
      exit={{ x: window.innerWidth }}
      style={{ overflowY: "unset" }}
    >
      <Helmet>
        <title>{"Рекомендації"}</title>
      </Helmet>
      <Container sx={{ overflow: "auto", marginTop: 5 }}>
        <Dialog
          onClose={() => {
            setAddButtonVisible(true);
            setEditForm(false);
            setEditedItem(null);
          }}
          open={editForm}
        >
          <EditAdvice item={editedItem} />
        </Dialog>

        <Filters
          data={filters}
          setData={(filtersData: AdviceCriteriaDto) => setFilters(filtersData)}
          onFilter={() => searchAdvices()}
        />

        {loading ? (
          <CircularProgress
            sx={{
              position: "fixed",
              top: "50%",
              left: "50%",
              transform: "translate(-50%, -50%)",
            }}
          />
        ) : (
          <Grid container spacing={5} justifyContent="center">
            {idAdmin && (
              <Grid item key={"newItemBtn"} xs={12} sm={6} md={4} lg={3}>
                <Box
                  height="100%"
                  display="flex"
                  justifyContent="center"
                  alignItems="center"
                >
                  {addButtonVisible && (
                    <Fab
                      color="primary"
                      aria-label="add"
                      variant="extended"
                      size="large"
                      onClick={() => {
                        setEditedItem(null);
                        setEditForm(true);
                      }}
                    >
                      <Add />
                    </Fab>
                  )}
                </Box>
              </Grid>
            )}

            {data?.map((item, index) => (
              <Grid item key={index} xs={12} sm={6} md={4} lg={3}>
                <Box height="100%" justifyContent="center" alignItems="center">
                  <AdviceCard
                    item={item}
                    token={jwtTokens!.accessToken}
                    onEdit={() => {
                      setEditedItem(item);
                      setEditForm(true);
                      setAddButtonVisible(false);
                    }}
                    isAdmin={idAdmin ?? false}
                    onDeleteAdvice={async () => {
                      setAddButtonVisible(false);
                      handleDeleteAdvice(jwtTokens!.accessToken, item.id);
                    }}
                    onView={(val: boolean) => setAddButtonVisible(val)}
                  />
                </Box>
              </Grid>
            ))}
          </Grid>
        )}
      </Container>
    </motion.div>
  );
};

export default Advices;
