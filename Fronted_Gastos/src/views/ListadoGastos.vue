<script setup>
import { ref, onMounted} from 'vue';
const datosGastos = ref([]);

async function cargarDatosApi() {
  let respuesta = await fetch('https://localhost:7216/api/Gastos')
  datosGastos.value = await respuesta.json();
}
onMounted(() => {
  cargarDatosApi();
});

</script>

<template>
  <div class="router-link">
    <p>
      <router-link to="/">Volver al inicio</router-link>
    </p>
  </div>
  <div class="router-link">
    <p>
      <router-link to="/AltaGastos">IR A REGISTRAR GASTOS</router-link>
    </p>
  </div>
  <div class="container">
    <h1>Listado de Gastos:</h1>

    <table class="tabla-gastos">
      <thead>

        <tr>
          <th>Monto</th>
          <th>Descripción</th>
          <th>Fecha</th>
          <th>Nombre del Comercio</th>
        </tr>

      </thead>

      <tbody>

        <tr v-for="gasto in datosGastos" :key="gasto.id">
          <td>${{ gasto.monto }}</td>
          <td>{{ gasto.descripcion }}</td>
          <td>{{ gasto.fecha.slice(0, 10) }}</td>
          <td>{{ gasto.nombreComercio }}</td>
        </tr>

      </tbody>
    </table>
  </div>

</template>

<style scoped>
.router-link a {
  text-decoration: none;
  color:black;
  padding: 12px 24px;
  border-radius: 8px;
  font-size: 18px;
}
.router-link a:hover {
  color: #007bff;
  transform: scale(1.1);
}
.container {
  padding: 20px;
  font-family: Arial, sans-serif;
}

.tabla-gastos {
  width: 100%;
  border-collapse: collapse;
  margin-top: 20px;
}

.tabla-gastos th,
.tabla-gastos td {
  border: 1px solid #ccc;
  padding: 10px;
  text-align: left;
}

.tabla-gastos th {
  background-color: #f2f2f2;
  font-weight: bold;
}

.tabla-gastos tr:nth-child(even) {
  background-color: #f9f9f9;
}
h1{
  text-align: center;
}
</style>
