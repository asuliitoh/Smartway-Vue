<script setup>
  import { ref } from 'vue'
  import Header from './components/Header.vue';
  import ToDoApp from './components/ToDoApp.vue';



</script>

<template>
 
    

    <div class="ml-10 mr-10 flex flex-grow flex-col h-screen ">
      <Header></Header>
      
      <section class="flex flex-col flex-grow justify-center">
        <h1 class="text-7xl text-center font-bold pb-5">¡Bienvenidos a la Operación DataStorm!</h1>
        <p class="text-xl text-center pb-10"> Lleva el control de tu día a día con nuestra app ToDo: simple, rápida y pensada
        para ayudarte a cumplir tus objetivos sin estrés. Organiza tus tareas, recibe recordatorios inteligentes
        y enfócate en lo que realmente importa. Empieza ahora y transforma tu caos en claridad con solo unos toques.
        </p>
         <ToDoApp class="self-center rounded-4xl w-fit"></ToDoApp>
      </section>
   

    </div>
    
  

</template>


<style>
@import "tailwindcss";
</style>
