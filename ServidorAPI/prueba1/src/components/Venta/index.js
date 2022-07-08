import React from 'react'
import VentaForm from './VentaForm'
import { useForm } from '../../hooks/useForm'
import SearchProducto from './SearchProducto';
import VentaProductos from './VentaProductos';
import { Grid } from '@material-ui/core';

const getFreshModelObject = () => ({
    VentaId: 0,
    ClienteId:0,
    MunicipioId:0,
    MTotal: 0,
    deletedVentaIds: '',
    Carritos: []
})

export default function Venta() {
    const {
        values,
        setValues,
        errors,
        setErrors,
        handleInputChange,
        resetFormControls
    } = useForm(getFreshModelObject);


    return (
        <Grid container spacing={2}>
            <Grid item xs={12}>
                <VentaForm
                    {...{ values,setValues ,errors,setErrors, handleInputChange, resetFormControls }}
                />
            </Grid>
            <Grid item xs={6}>
                <SearchProducto
                    {...{  values,
                     setValues}} />
            </Grid>
            <Grid item xs={6}>
                <VentaProductos 
                {...{
                 values,
                 setValues}}/>
            </Grid>
        </Grid>
    )

}