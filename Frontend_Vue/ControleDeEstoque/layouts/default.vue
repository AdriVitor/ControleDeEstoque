<template>
  <div class="container-xl">
   <v-card class="overflow-hidden">
    <v-app-bar
      color="rgb(62, 125, 213)"
      dark
    >
      <template v-slot:img="{ props }">
        <v-img v-bind="props" gradient="to top right, rgba(100,115,201,.7), rgba(25,32,72,.7)"></v-img>
      </template>

      <v-toolbar-title class="title">
        <v-icon dark small>mdi-table</v-icon>
        Controle de Estoque
      </v-toolbar-title>

      <template v-slot:extension>
        <v-tabs align-with-title>
          <v-tab class="v-tab"><v-icon class="icons" small>mdi-home</v-icon>
            <Nuxt-Link to="home">
            Home
          </Nuxt-Link>
        </v-tab>

          <v-tab class="v-tab">
            <v-icon>mdi-playlist-edit</v-icon>
            <Nuxt-Link to="products"> Produtos
            </Nuxt-Link>
          </v-tab>

        </v-tabs>
      </template>
    </v-app-bar>
  </v-card>
    <div>
      <Nuxt />
    </div>
  </div>
</template>

<script>

export default{
  name: 'default'
}
</script>

<style>
  .title{
    font-size:20px;
  }
  body{
    background-color: rgb(255, 255, 255);
  }
  .v-tab{
    font-size:14px;
    color:white;
    text-decoration: none;
  }

</style>
