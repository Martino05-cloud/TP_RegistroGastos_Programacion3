<script setup>

</script>

<template>
  <div class="container">
    <div class="caja">
      <h1>
        <router-link to="/AltaGastos">REGISTRAR GASTO</router-link>
      </h1>
      <h1>
        <router-link to="/ListadoGastos">LISTADO DE GASTOS</router-link>
      </h1>
    </div>
  </div>
</template>

<style scoped>
.container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  flex-direction: column;
}

.caja {
  background-color: #f9f9f9;
  border: 2px solid #ccc;
  border-radius: 12px;
  padding: 30px 40px;
  text-align: center;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
  transition: transform 0.3s ease, box-shadow 0.3s ease;
}

.caja:hover {
  transform: scale(1.03);
  box-shadow: 0 6px 16px rgba(0, 0, 0, 0.25);
}

.caja h1 {
  margin: 20px 0;
  font-size: 1.5rem;
}

.router-link-active,
a {
  text-decoration: none;
  color: #2c3e50;
  font-weight: bold;
  font-size: 1.2rem;
}

a:hover {
  color: #007BFF;
}
</style>
