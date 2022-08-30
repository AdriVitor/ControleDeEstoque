<template>
<div class="container">
  <div id="div-form-products">
    <form @submit.prevent="submit" id="form-products">

      <v-text-field
        v-model="FormData.name"
        id="name"
        name="name"
        :counter="40"
        placeholder="Nome do Produto"
        required
        class="form-inputs"
      ></v-text-field>

      <v-text-field
        v-model="FormData.quantity"
        id="quantity"
        name="quantity"
        :counter="3"
        type="number"
        placeholder="Quantidade em estoque"
        required
        class="form-inputs"
      ></v-text-field>

      <v-text-field
        v-model="FormData.price"
        id="price"
        name="price"
        type="number"
        step="any"
        placeholder="Preço"
        required
        class="form-inputs"
      ></v-text-field>

      <div id="form-buttons">
        <v-btn
          class="mr-4"
          type="submit"
          id="button-success"
        >
          Cadastrar
        </v-btn>
      </div>
      </form>
  </div>


  <v-simple-table
    fixed-header
    id="table"
  >
      <thead>
        <tr>
          <th>Produto</th>
          <th>Preço</th>
          <th>Quantidade</th>
          <th colspan="2"></th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="product in products"
          :key="product.id"
        >
          <td>{{ product.name }}</td>
          <td>{{ product.price }}</td>
          <td>{{product.quantity}}</td>

          <td>
            <v-btn
              x-small
              id="button-update"
              v-on:click="editar(product)"
            >
            Alterar
          </v-btn>
          </td>

          <td>
            <v-btn
              x-small
              id="button-delete"
              v-on:click="excluir(product.id)"
            >
              Excluir
            </v-btn>
          </td>

          </tr>

      </tbody>

  </v-simple-table>


</div>
</template>

<script>
import api from '@/services/api.js';
export default{
  name: 'list-products',
  data(){
    return{
      FormData:{
          name:'',
          quantity: '',
          price: ''
        },
      products: [],
      product: undefined
    }
  },
  mounted(){
    this.listar()
  },
  methods:{
    listar(){
      api.get('all-products').then(response=>{
        this.products = response.data;
      })
    },
    submit(){
      if(this.product){
        this.alterar();
        return
      }
      api.post('/product/create', this.FormData)
      .then(()=>{
        alert("Produto salvo com sucesso!");
        this.listar()
      })
      .catch(err => console.log(err));
    },

    editar(product){
      document.getElementById("name").value = product.name
      document.getElementById("quantity").value = product.quantity
      document.getElementById("price").value = product.price
      this.product = product;
    },

    alterar(){
      this.product.name = document.getElementById("name").value
      this.product.quantity = document.getElementById("quantity").value
      this.product.price = document.getElementById("price").value

      api.put(`/product/update/${this.product.id}`, this.product)
        .then(()=>{
          alert("Produto salvo com sucesso!");
          this.listar()
          this.product = undefined
        })
        .catch(err => console.log(err));
    },

    excluir(id){
      if(confirm("Tem certeza que deseja excluir esse produto?")){
        api.delete(`/product/delete/${id}`,)
        .then(()=>this.listar())
        .catch(err => console.log(err));
      }
    }
  }
}
</script>

<style>
.container{
  display:flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

#table {
  width: 100vh;
}

#button-success{
  display:flex;
  background-color: rgb(62, 182, 35);
}

#button-delete {
  background-color: rgb(211, 73, 73);
  padding: 12px 12px;
}

#button-update {
  background-color: rgb(62, 125, 213);
}

.form-inputs{
  width: 500px;
}

#form-products{
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: start;
  margin-top: 35px;
  margin-bottom: 25px;
}

#form-buttons {
  display: flex;
  justify-content: start;
  align-items: flex-start;
}

#div-form-products{
  display: flex;
  flex-direction: center;
}
.form-inputs{
  width: 100vh;
}

</style>
