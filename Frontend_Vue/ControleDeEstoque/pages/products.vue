<template>
  <div>
  <v-main>
    <list-products></list-products>
  </v-main>
  </div>
</template>

<script>
import ListProducts from '../components/list-products.vue';
export default{
    name: "products",
    components: { ListProducts }
}

</script>

