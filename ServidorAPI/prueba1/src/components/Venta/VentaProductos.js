import { Button, ButtonGroup, IconButton, List, Paper, ListItem, ListItemText, ListItemSecondaryAction,makeStyles } from '@material-ui/core';
import React from 'react'
import DeleteTwoToneIcon from '@material-ui/icons/DeleteTwoTone'
import { roundTo2DecimalPoint } from '../../utils';
import { variables } from '../../Variables';

const useStyles=makeStyles(theme=>({
    paperRoot: {
        margin: '15px 0px',
        '&:hover': {
            cursor: 'pointer'
        },
        '&:hover $deleteButton': {
            display: 'block'
        }
    },
    buttonGroup: {
        backgroundColor: '#E3E3E3',
        borderRadius: 8,
        '& .MuiButtonBase-root ': {
            border: 'none',
            minWidth: '25px',
            padding: '1px'
        },
        '& button:nth-child(2)': {
            fontSize: '1.2em',
            color: '#000'
        }
    },
    deleteButton: {
        display: 'none',
        '& .MuiButtonBase-root': {
            color: '#E81719'
        },
    },
    totalPerItem: {
        fontWeight: 'bolder',
        fontSize: '1.2em',
        margin: '0px 10px'
    }
}))

export default function VentaProductos(props) {

    const { values, setValues } = props;
    const classes=useStyles();

    let VentaProductos = values.Carritos;

    const removeProducto=(index,id)=>{
        let x={...values};
        x.Carritos=x.Carritos.filter((_,i)=>i!=index);
        setValues({...x});
    }

    const updateCantidad = (idx, value) => {
        let x = { ...values };
        let producto=x.Carritos[idx];
        if (producto.Cantidad + value > 0) {
            producto.Cantidad += value;
            setValues({ ...x });
        }
    }

    return (
        <List>
            {VentaProductos.length==0?
            <ListItem>
                <ListItemText
                primary="Por favor ingrese productos a su carrito"
                primaryTypographyProps={{
                    style:{
                        textAlign:'center',
                        fontStyle:'italic'
                    }
                }}
                />
            </ListItem>
                :VentaProductos.map((item, idx) => (
                    <Paper key={idx} className={classes.paperRoot}>
                        <ListItem>
                            <ListItemText
                                primary={item.ProductoNombre}
                                primaryTypographyProps={{
                                    component: 'h1',
                                    style: {
                                        fontWeight: '500',
                                        fontSize: '1.2em'
                                    }
                                }}
                                secondary={
                                    <>
                                        <ButtonGroup
                                        className={classes.buttonGroup}
                                            size="small">
                                            <Button
                                                onClick={e => updateCantidad(idx, -1)}>-</Button>
                                            <Button disabled>{item.Cantidad}</Button>
                                            <Button
                                                onClick={e => updateCantidad(idx, 1)}>+</Button>
                                        </ButtonGroup>
                                        <span className={classes.totalPerItem}>
                                            {'C$'+roundTo2DecimalPoint( item.Cantidad*item.ProductoPrecio)}
                                        </span>
                                    </>
                                }
                                secondaryTypographyProps={{
                                    component:'div'
                                }}
                            />
                            
                            <ListItemSecondaryAction
                            className={classes.deleteButton}>
                                <IconButton
                                    disableRipple
                                    onClick={e => removeProducto(idx, item.CarritoId)}>
                                    <DeleteTwoToneIcon />
                                </IconButton>
                            </ListItemSecondaryAction>
                            
                        </ListItem>
                    </Paper>
                ))
            }
        </List>
    )
}