<script setup>
import { ref } from 'vue';

const Monto = ref('');
const Descripcion = ref('');
const fecha = ref('');
const nombreComercio = ref('');

const mensajeExito = ref('');

const errorMonto = ref('');
const errorDescripcion = ref('');
const errorFecha = ref('');
const errorComercio = ref('');

const guardarDatosApi = async () => {
  // Reiniciar errores
  errorMonto.value = '';
  errorDescripcion.value = '';
  errorFecha.value = '';
  errorComercio.value = '';
  mensajeExito.value = '';

  const monto = parseFloat(Monto.value);
  const descripcion = Descripcion.value.trim();
  const fechaIngresada = new Date(fecha.value);
  const hoy = new Date();
  const comercio = nombreComercio.value.trim();

  // Validaciones
  if (!Monto.value || isNaN(monto) || monto <= 0) {
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

  // Envío a la API si pasa todas las validaciones
  const nuevoGasto = {
    monto,
    descripcion,
    fecha: fecha.value,
    nombreComercio: comercio
  };

  try {
    const respuesta = await fetch('https://localhost:7216/api/Gastos', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(nuevoGasto)
    });

    if (respuesta.ok) {
      mensajeExito.value = 'Gasto guardado correctamente.';
      // Limpiar campos
      Monto.value = '';
      Descripcion.value = '';
      fecha.value = '';
      nombreComercio.value = '';
    } else {
      const errorData = await respuesta.json();
      console.error('Error al guardar:', errorData);
    }

  } catch (error) {
    console.error('Error en fetch:', error);
  }

  // Limpiar mensaje de éxito luego de 3 segundos
  setTimeout(() => {
    mensajeExito.value = '';
  }, 3000);
};
</script>

<template>
  <div class="form-container">
    <h1>Registrar Gasto</h1>
    <form @submit.prevent="guardarDatosApi">
      <div class="form-group">
        <label>Monto:</label>
        <input v-model="Monto" type="number" />
        <span v-if="errorMonto" class="error">{{ errorMonto }}</span>
      </div>

      <div class="form-group">
        <label>Descripción:</label>
        <input v-model="Descripcion" type="text" />
        <span v-if="errorDescripcion" class="error">{{ errorDescripcion }}</span>
      </div>

      <div class="form-group">
        <label>Fecha:</label>
        <input v-model="fecha" type="date" />
        <span v-if="errorFecha" class="error">{{ errorFecha }}</span>
      </div>

      <div class="form-group">
        <label>Nombre del Comercio:</label>
        <input v-model="nombreComercio" type="text" />
        <span v-if="errorComercio" class="error">{{ errorComercio }}</span>
      </div>

      <button type="submit">Guardar</button>

      <p v-if="mensajeExito" class="success">{{ mensajeExito }}</p>
    </form>
  </div>

  <div class="botones-navegacion">
    <router-link to="/" class="router-button">Volver al inicio</router-link>
    <router-link to="/ListadoGastos" class="router-button">Ver Listado</router-link>
  </div>
</template>

<style scoped>
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
  margin-bottom: 5px;
  font-weight: bold;
}

input {
  width: 100%;
  padding: 8px;
  box-sizing: border-box;
}

button {
  width: 100%;
  padding: 10px;
  background-color: #28a745;
  color: white;
  border: none;
  cursor: pointer;
}

button:hover {
  background-color: #218838;
}

.error {
  color: red;
  font-size: 0.9em;
}

.success {
  color: green;
  font-weight: bold;
  margin-top: 10px;
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
