<script setup>

const props = defineProps(['title'])
const done = defineModel({required: true, default: false})
const emit = defineEmits(['completed'])

</script>

<template>

     <label id="checkboxs" for="checkbox" class="flex text-lg">
      <input type="checkbox" id="checkbox" v-model="done">
      <p class="tarea"> {{ props.title }}
          <span class="font-semibold" v-if="done">(Hecha)</span>
          <span class="font-semibold" v-else>(No hecha)</span>
      </p>
        
      </label>


</template>

<style scoped>
</style>