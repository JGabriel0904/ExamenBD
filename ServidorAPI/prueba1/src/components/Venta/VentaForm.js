import React, { useState, useEffect } from 'react'
import Form from "../../layouts/Form";
import Popup from '../../layouts/Popup';
import { Grid, InputAdornment, makeStyles, ButtonGroup, Button as MuiButton } from '@material-ui/core';
import { Input, Select, Button } from "../../controls";
import ReplayIcon from '@material-ui/icons/Replay'
import ShoppingCart from '@material-ui/icons/ShoppingCart'
import ReorderIcon from '@material-ui/icons/Reorder';
import { createAPIEndpoint, ENDPIONTS } from "../../api"
import { roundTo2DecimalPoint } from '../../utils';




const useStyles = makeStyles(theme => ({
    adornmentText: {
        '& .MuiTypography-root': {
            color: '#f3b33d',
            fontWeight: 'bolder',
            fontSize: '1.5em'
        }
    },
    submitButtonGroup: {
        backgroundColor: '#f3b33d',
        color: '#000',
        margin: theme.spacing(1),
        '& .MuiButton-label': {
            textTransform: 'none'
        },
        '&:hover': {
            backgroundColor: '#f3b33d',
        }
    }
}))

export default function VentaForm(props) {

    const { values, setValues, errors, setErrors,
        handleInputChange, resetFormControls } = props;
    const classes = useStyles();

    const [clienteList, setClienteList] = useState([])

    useEffect(() => {
        createAPIEndpoint(ENDPIONTS.CLIENTE).fetchAll()
            .then(res => {
                let clienteList = res.data.map(item => ({
                    id: item.ClienteId,
                    title: item.ClienteNombre
                }))
                clienteList = [{ id: 0, title: 'Seleccione' }].concat(clienteList);
                setClienteList(clienteList);
            })
            .catch(err => console.log(err))
    }, [])

    useEffect(() => {
        let MTotal = values.Carritos.reduce((tempTotal, item) => {
            return tempTotal + (item.Cantidad * item.ProductoPrecio);
        }, 0);
        setValues({
            ...values,
            MTotal: roundTo2DecimalPoint(MTotal)
        })

    }, [JSON.stringify(values.Carritos)]);


    const validateForm = () => {
        let temp = {};
        temp.ClienteId = values.ClienteId != 0 ? "" : "Este campo es requerido.";
        temp.Municipio = values.ClienteId != "none" ? "" : "Este campo es requerido";
        temp.Carritos = values.Carritos.length != 0 ? "" : "Este campo es requerido";
        setErrors({ ...temp });
        return Object.values(temp).every(x => x === "");
    }

    const submitVenta = e => {
        e.preventDefault();
        if (validateForm()) {
            createAPIEndpoint(ENDPIONTS.VENTA).create(values)
                .then(res => {
                    resetFormControls();
                })
                .catch(err => console.log(err));
        }
    }


    return (
        <>
            <Form onSubmit={submitVenta}>
                <Grid container>
                    <Grid item xs={6}>
                       
                        <Select
                            label="Cliente"
                            name="ClienteId"
                            value={values.ClienteId}
                            onChange={handleInputChange}
                            options={clienteList}
                            error={errors.ClienteId}
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <Select
                            label="Municipio"
                            name="Municipio"
                            value={values.Municipio}
                            onChange={handleInputChange}
                            options={[
                                { id: 'none', title: 'Seleccione' },
                                { id: 'Juigalpa', title: 'Juigalpa' },
                                { id: 'Cuapa', title: 'Cuapa' },
                            ]}
                            errors={errors.Municipio}
                        />
                        <Input
                            disabled
                            label="Monto Total"
                            name="MTotal"
                            value={values.MTotal}
                            InputProps={{
                                startAdornment: <InputAdornment
                                    className={classes.adornmentText}
                                    position="start">C$</InputAdornment>
                            }}
                        />
                        <ButtonGroup className={classes.submitButtonGroup}>
                            <MuiButton
                                size="large"
                                endIcon={<ShoppingCart />}
                                type="submit">Comprar</MuiButton>
                        </ButtonGroup>
                    </Grid>
                </Grid>
            </Form>
        </>
    )
}