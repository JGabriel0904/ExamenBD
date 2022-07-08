import React,{Component} from 'react';
import {variables} from './Variables.js';

export class Producto extends Component{

    constructor(props){
        super(props);

        this.state={
            categorias:[],
            productos:[],
            modalTitle:"",
            ProductoId:0,
            ProductoNombre:"",
            Categoria:"",
            Precio:0,
            Fecha_registro:"",
            PhotoFileName:"anonymous.png",
            PhotoPath:variables.PHOTO_URL
        }
    }

    refreshList(){

        fetch(variables.API_URL+'producto')
        .then(response=>response.json())
        .then(data=>{
            this.setState({productos:data});
        });

        fetch(variables.API_URL+'categoria')
        .then(response=>response.json())
        .then(data=>{
            this.setState({categorias:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }
    
    changeCategoria =(e)=>{
        this.setState({Categoria:e.target.value});
    }

    changePrecio =(e)=>{
        this.setState({Precio:e.target.value});
    }
    
    changeProductoNombre =(e)=>{
        this.setState({ProductoNombre:e.target.value});
    }
    
    changeFecha_registro =(e)=>{
        this.setState({Fecha_registro:e.target.value});
    }

    addClick(){
        this.setState({
            modalTitle:"Agregar Producto",
            ProductoId:0,
            ProductoNombre:"",
            Categoria:"",
            Precio:0,
            Fecha_registro:"",
            PhotoFileName:"anonymous.png"
        });
    }
    editClick(pro){
        this.setState({
            modalTitle:"Editar Producto",
            ProductoId:pro.ProductoId,
            ProductoNombre:pro.ProductoNombre,
            Categoria:pro.Categoria,
            Precio:pro.Precio,
            Fecha_registro:pro.Fecha_registro,
            PhotoFileName:pro.PhotoFileName
        });
    }

    createClick(){
        fetch(variables.API_URL+'producto',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                ProductoNombre:this.state.ProductoNombre,
                Categoria:this.state.Categoria,
                Precio:this.state.Precio,
                Fecha_registro:this.state.Fecha_registro,
                PhotoFileName:this.state.PhotoFileName
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            alert(result);
            this.refreshList();
        },(error)=>{
            alert('Failed');
        })
    }


    updateClick(id){
        fetch(variables.API_URL+'producto/'+id,{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                ProductoId:this.state.ProductoId,
                Categoria:this.state.Categoria,
                ProductoNombre:this.state.ProductoNombre,
                Precio:this.state.Precio,
                Fecha_registro:this.state.Fecha_registro,
                PhotoFileName:this.state.PhotoFileName
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            alert(result);
            this.refreshList();
        },(error)=>{
            alert('Failed');
        })
    }

    deleteClick(id){
        if(window.confirm('Are you sure?')){
        fetch(variables.API_URL+'producto/'+id,{
            method:'DELETE',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            }
        })
        .then(res=>res.json())
        .then((result)=>{
            alert(result);
            this.refreshList();
        },(error)=>{
            alert('Failed');
        })
        }
    }

    imageUpload=(e)=>{
        e.preventDefault();

        const formData=new FormData();
        formData.append("file",e.target.files[0],e.target.files[0].name);

        fetch(variables.API_URL+'producto/savefile',{
            method:'POST',
            body:formData
        })
        .then(res=>res.json())
        .then(data=>{
            this.setState({PhotoFileName:data});
        })
    }

    render(){
        const {
            categorias,
            productos,
            modalTitle,
            ProductoId,
            ProductoNombre,
            Categoria,
            Precio,
            Fecha_registro,
            PhotoPath,
            PhotoFileName
        }=this.state;

        return(
<div>

    <button type="button"
    className="btn btn-dark btn-otuline-secundary m-2 float-end"
    data-bs-toggle="modal"
    data-bs-target="#exampleModal"
    onClick={()=>this.addClick()}>
        Agregar Producto
    </button>
    <table className="table table-striped">
    <thead>
    <tr>
        <th>
            ProductoId
        </th>
        <th>
            ProductoNombre
        </th>
        <th>
            Categoria
        </th>
        <th>
            Precio
        </th>
        <th>
            Fecha de Registro
        </th>
        <th>
            Imagen
        </th>
        <th>
            Opciones
        </th>
    </tr>
    </thead>
    <tbody>
        {productos.map(pro=>
            <tr key={pro.ProductoId}>
                <td>{pro.ProductoId}</td>
                <td>{pro.ProductoNombre}</td>
                <td>{pro.Categoria}</td>
                <td>{pro.Precio}</td>
                <td>{pro.Fecha_registro}</td>
                <td><img src={PhotoPath+pro.PhotoFileName} alt={pro.PhotoFileName} width="50" height="50"></img></td>
                <td>
                <button type="button"
                className="btn btn-light m-1"
                data-bs-toggle="modal"
                data-bs-target="#exampleModal"
                onClick={()=>this.editClick(pro)}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-pencil-square" viewBox="0 0 16 16">
                    <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                    <path fillRule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
                    </svg>
                </button>

                <button type="button"
                className="btn btn-light m-1"
                onClick={()=>this.deleteClick(pro.ProductoId)}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-trash-fill" viewBox="0 0 16 16">
                    <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"/>
                    </svg>
                </button>
 
                </td>
            </tr>
            )}
    </tbody>
    </table>

<div className="modal fade" id="exampleModal" tabIndex="-1" aria-hidden="true">
<div className="modal-dialog modal-lg modal-dialog-centered">
<div className="modal-content">
   <div className="modal-header">
       <h5 className="modal-title">{modalTitle}</h5>
       <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"
       ></button>
   </div>

   <div className="modal-body">
    <div className="d-flex flex-row bd-highlight mb-3">
     
     <div className="p-2 w-50 bd-highlight">
        
        <div className="input-group mb-3">
            <span className="input-group-text">Nombre Producto</span>
            <input type="text" className="form-control"
            value={ProductoNombre}
            onChange={this.changeProductoNombre}/>
        </div>

        <div className="input-group mb-3">
            <span className="input-group-text">Categoria</span>
            <select className="form-select"
            onChange={this.changeCategoria}
            value={Categoria}>
                {categorias.map(cat=><option key={cat.CategoriaId}>
                    {cat.CategoriaNombre}
                </option>)}
            </select>
        </div>
        <div className="input-group mb-3">
            <span className="input-group-text">Precio</span>
            <input type="text" className="form-control"
            value={Precio}
            onChange={this.changePrecio}/>
        </div>

        <div className="input-group mb-3">
            <span className="input-group-text">DOJ</span>
            <input type="date" className="form-control"
            value={Fecha_registro}
            onChange={this.changeFecha_registro}/>
        </div>


     </div>
     <div className="p-2 w-50 bd-highlight">
         <img width="250px" height="250px"
         src={PhotoPath+PhotoFileName}/>
         <input className="m-2" type="file" onChange={this.imageUpload}/>
     </div>
    </div>

    {ProductoId==0?
        <button type="button"
        className="btn btn-primary float-start"
        onClick={()=>this.createClick()}
        >Create</button>
        :null}

        {ProductoId!=0?
        <button type="button"
        className="btn btn-primary float-start"
        onClick={()=>this.updateClick(ProductoId)}
        >Update</button>
        :null}
   </div>

</div>
</div> 
</div>


</div>
        )
    }
}