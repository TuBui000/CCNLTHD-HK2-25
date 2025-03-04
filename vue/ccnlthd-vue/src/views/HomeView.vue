<script setup>
import todolistImg from '../image/todoList.png'
import calculatorImg from '../image/calculator.png'
import weatherImg from '../image/weather.png'

const images = [
  { src: todolistImg, alt: 'Biểu tượng ứng dụng Todoist', path:"todolist" },
  { src: weatherImg, alt: 'Biểu tượng ứng dụng Todoist', path:"weather" },
  { src: calculatorImg, alt: 'Biểu tượng ứng dụng Todoist', path:"calculator" },
]

const isHovered = [false, false, false]

function hover(index, value) {
  isHovered[index] = value
}
</script>

<template>
  <div class="bg-dark d-flex align-items-center justify-content-center vh-100">
    <div class="container text-center p-4">
      <div class="justify-content-center g-0">
        <h2 class="text-bg-dark">CHOOSE AN APP</h2>
      </div>
      <div class="row row-cols-1 row-cols-md-5 g-5 justify-content-center mt-2">
        <div class="col" v-for="(image, id) in images" :key="id">
          <div class="card hover-shadow" @mouseover="hover(id, true)" @mouseleave="hover(id, false)"
            :class="{ 'hover-shadow': isHovered[id] }">
            <RouterLink :to="image.path">            
              <img :src="image.src" class="card-img-top rounded img-fluid" :alt="image.alt">
            </RouterLink>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
