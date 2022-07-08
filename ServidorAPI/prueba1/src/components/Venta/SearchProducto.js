import { Paper, IconButton, InputBase, List, ListItem, ListItemText, makeStyles, ListItemSecondaryAction } from '@material-ui/core'
import React, { useState, useEffect } from 'react'
import { createAPIEndpoint, ENDPIONTS } from '../../api'
import SearchTwoToneIcon from '@material-ui/icons/SearchTwoTone'
import PlusOneIcon from '@material-ui/icons/PlusOne'
import ArrowForwardIosIcon from '@material-ui/icons/ArrowForwardIos'
import { variables } from '../../Variables'

const useStyles = makeStyles(theme => ({
    searchPaper: {
        padding: '2px 4px',
        display: 'flex',
        alignItems: 'center',
    },
    searchInput: {
        marginLeft: theme.spacing(1.5),
        flex: 1,
    },
    listRoot: {
        marginTop: theme.spacing(1),
        maxHeight: 450,
        overflow: 'auto',
        '& li:hover': {
            cursor: 'pointer',
            backgroundColor: '#E3E3E3'
        },
        '& li:hover .MuiButtonBase-root': {
            display: 'block',
            color: '#000',
        },
        '& .MuiButtonBase-root': {
            display: 'none'
        },
        '& .MuiButtonBase-root:hover': {
            backgroundColor: 'transparent'
        }
    }

}))


export default function SearchProducto(props) {

    



    const { values, setValues } = props;

    let VentaProductos = values.Carritos;

    const [productos, setProductos] = useState([])
    const [searchList, setSearchList] = useState([]);
    const [searchKey, setSearchKey] = useState('');
    const classes = useStyles();

    useEffect(() => {
        createAPIEndpoint(ENDPIONTS.PRODUCTO).fetchAll()
            .then(res => {
                setProductos(res.data);
                setSearchList(res.data);
            })
            .catch(err => console.log(err))
    }, [])

    useEffect(() => {
        let x = [...productos];
        x = x.filter(y => {
            return y.ProductoNombre.toLowerCase().includes(searchKey.toLocaleLowerCase())
                && VentaProductos.every(item => item.ProductoId != y.ProductoId)
        });
        setSearchList(x);
    }, [searchKey, VentaProductos])

    const addProducto = producto => {
        let x = {
            VentaId: values.VentaId,
            CarritoId: 0,
            ProductoId: producto.ProductoId,
            Cantidad: 1,
            ProductoPrecio: producto.Precio,
            ProductoNombre: producto.ProductoNombre,
            PhotoFileName:"anonymous.png",
            PhotoPath:variables.PHOTO_URL

        }
        setValues({
            ...values,
            Carritos: [...values.Carritos, x]
        })
    }

    return (
        <>
            <Paper className={classes.searchPaper}>
                <InputBase
                    className={classes.searchInput}
                    value={searchKey}
                    onChange={e => setSearchKey(e.target.value)}
                    placeholder="Buscar productos" />
                <IconButton>
                    <SearchTwoToneIcon />
                </IconButton>
            </Paper>
            <List className={classes.listRoot}>
                {
                    searchList.map((item, idx) => (
                        
                        <ListItem
                        
                            key={idx}
                            onClick={e => addProducto(item)}>
                            <ListItemText
                                primary={item.ProductoNombre}
                                secondary={'C$' + item.Precio} 
                                />
                                <ListItemSecondaryAction>
                                   <img src={variables.PHOTO_URL+item.PhotoFileName} width="50" height="50"></img> 
                                </ListItemSecondaryAction>
                            <ListItemSecondaryAction>
                                <IconButton onClick={e => addProducto(item)}>
                                    <PlusOneIcon />
                                    <ArrowForwardIosIcon />
                                </IconButton>
                            </ListItemSecondaryAction>
                            
                        </ListItem>
                    ))
                }
            </List>
        </>
    )
}