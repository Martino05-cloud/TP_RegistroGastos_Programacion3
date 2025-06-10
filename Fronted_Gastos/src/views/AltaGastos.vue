<script setup>
import { ref } from 'vue';

let Monto = ref('');
let Descripción = ref('');
let fecha = ref('');
let nombreComercio = ref('');

let mensajeExito = ref('');

let errorMonto = ref('');
let errorDescripcion = ref('');
let errorFecha = ref('');
let errorComercio = ref('');

async function guardarDatosApi() {

  errorMonto.value = '';
  errorDescripcion.value = '';
  errorFecha.value = '';
  errorComercio.value = '';

  const monto = parseFloat(Monto.value);
  const descripcion = Descripción.value.trim();
  const fechaIngresada = new Date(fecha.value);
  const hoy = new Date();
  const comercio = nombreComercio.value.trim();


  if (isNaN(monto) || monto <= 0) {
    errorMonto.value = "El monto es obligatorio y debe ser mayor a 0";
    return;
  }

  if (descripcion.length < 3 || descripcion.length > 250) {
    errorDescripcion.value = "La descripción debe tener entre 3 y 250 caracteres";
    return;
  }

  if (!fecha.value || fechaIngresada > hoy) {
    errorFecha.value = "La fecha es obligatoria y no puede ser futura";
    return;
  }

  if (comercio.length === 0 || comercio.length > 250) {
    errorComercio.value = "El nombre del comercio es obligatorio y debe tener hasta 250 caracteres";
    return;
  }

  // Si pasa validaciones guardamos
  const nuevoGasto = {
    monto,
    descripcion,
    fecha: fecha.value,
    nombreComercio: comercio
  };

  try {
    const respuesta = await fetch('https://localhost:7216/api/Gastos', {
      method: 'POST',
      body: JSON.stringify(nuevoGasto),
      headers: {
        'Content-Type': 'application/json'
      }
    });

    if (respuesta.ok) {

      Monto.value = '';
      Descripción.value = '';
      fecha.value = '';
      nombreComercio.value = '';
      mensajeExito.value = 'Gasto guardado correctamente.';
    }
    setTimeout(() => {
    mensajeExito.value = '';
  }, 3000);

  } catch (error) {
    console.error(error);
  }
}
</script>

<template>
  <div class="router-link">
    <p>
      <router-link to="/">Volver al inicio</router-link>
    </p>
  </div>
  <div class="router-link">
    <p>
      <router-link to="/ListadoGastos"> VER HISTORIAL DE GASTOS</router-link>
    </p>
  </div>
  <div class="form-container">
    <h1>Registrar Gasto</h1>

    <form @submit.prevent="guardarDatosApi">

      <div class="form-group">
        <label>Monto:</label>
        <input v-model="Monto" type="number" required />
        <span v-if="errorMonto" class="error-message">{{ errorMonto }}</span>
      </div>

      <div class="form-group">
        <label>Descripción:</label>
        <input v-model="Descripción" type="text" required />
        <span v-if="errorDescripcion" class="error-message">{{ errorDescripcion }}</span>
      </div>

      <div class="form-group">
        <label>Fecha:</label>
        <input v-model="fecha" type="date" required />
        <span v-if="errorFecha" class="error-message">{{ errorFecha }}</span>
      </div>

      <div class="form-group">
        <label>Nombre del Comercio:</label>
        <input v-model="nombreComercio" type="text" required />
        <span v-if="errorComercio" class="error-message">{{ errorComercio }}</span>
      </div>

      <button type="submit">Guardar</button>

      <p v-if="mensajeExito" class="mensaje-exito">{{ mensajeExito }}</p>
    </form>
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
.error-message {
  color: red;
  font-size: 0.9em;
  margin-top: 5px;
}
.form-container {
  max-width: 500px;
  margin: auto;
  padding: 20px;
  font-family: Arial, sans-serif;
}

h1 {
  text-align: center;
}

.form-group {
  margin-bottom: 15px;
}

label {
  display: block;
  font-weight: bold;
  margin-bottom: 5px;
}

input {
  width: 100%;
  padding: 8px;
  box-sizing: border-box;
}

button {
  background-color: #28a745;
  color: white;
  padding: 10px 20px;
  border: none;
  cursor: pointer;
  width: 100%;
}

button:hover {
  background-color: #218838;
}
.mensaje-exito {
  color: green;
  margin-top: 10px;
  font-weight: bold;
}
</style>
