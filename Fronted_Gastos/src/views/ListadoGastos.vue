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

    <div class="botones-navegacion">
      <router-link to="/" class="router-button">Volver al inicio</router-link>
      <router-link to="/AltaGastos" class="router-button">Registrar Gasto</router-link>
    </div>
  </div>
</template>

<style scoped>
.container {
  max-width: 800px;
  margin: 0 auto;
  padding: 20px;
  text-align: center;
}

h1 {
  margin-bottom: 20px;
  color: #333;
}

.tabla-gastos {
  width: 100%;
  max-width: 100%;
  border-collapse: collapse;
  margin-bottom: 30px;
  background-color: #fff;
  box-shadow: 0 2px 6px rgba(0, 0, 0, 0.1);
}

.tabla-gastos th,
.tabla-gastos td {
  border: 1px solid #ddd;
  padding: 12px 16px;
  text-align: left;
}

.tabla-gastos th {
  background-color: #f4f4f4;
  color: #333;
}

.tabla-gastos tr:nth-child(even) {
  background-color: #f9f9f9;
}

.botones-navegacion {
  display: flex;
  justify-content: center;
  gap: 20px;
  margin-top: 20px;
}

.router-button {
  text-decoration: none;
  background-color: #3498db;
  color: white;
  padding: 10px 20px;
  border-radius: 6px;
  transition: background-color 0.3s;
}

.router-button:hover {
  background-color: #2980b9;
}
</style>
