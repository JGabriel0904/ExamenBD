import React,{Component} from 'react';
import {variables} from './Variables.js';

export class Venta extends Component{

    constructor(props){
        super(props);

        this.state={
            ventas:[],
            modalTitle:"",
            Municipio:"",
            VentaId:0,
            Fecha_registro:"",

        }
    }



    refreshList(){
        fetch(variables.API_URL+'venta')
        .then(response=>response.json())
        .then(data=>{
            this.setState({ventas:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }
    








    render(){
        const {
            ventas,
            modalTitle,
            VentaId,
            Municipio,
            Fecha_registro
        }=this.state;

        return(
<div>

    <table className="table table-striped">
    <thead>
    <tr>
        <th>
            VentaId
        </th>
        <th>
            ClienteId
        </th>
        <th>
            Municipio
      
        </th>
        <th>
            Monto Total
        </th>
        <th>
            Fecha de Venta
        </th>
    </tr>
    </thead>
    <tbody>
        {ventas.map(v=>
            <tr key={v.VentaId}>
                <td>{v.VentaId}</td>
                <td>{v.ClienteId}</td>
                <td>{v.Municipio}</td>
                <td>{v.MTotal}</td>
                <td>{v.Fecha_registro}</td>
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
       

   </div>

</div>
</div> 
</div>


</div>
        )
    }
}