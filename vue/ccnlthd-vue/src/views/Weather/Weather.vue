<script setup>
import { computed, ref } from 'vue';


const api_key = ref('73551a05bf88dd7eb8b41f869659fb5d');
const url_base = ref('https://api.openweathermap.org/data/2.5/');
const query = ref('');
const weather = ref({});

const fetchWeather = (e) => {
  if (e.key === "Enter") {
    fetch(`${url_base.value}weather?q=${query.value}&units=metric&APPID=${api_key.value}`)
      .then(res => res.json())
      .then(setResults);
  }
};

const setResults = (results) => {
  weather.value = results;
};

const months = ["January", "February", "March", "April", "May", "June", "July",
    "August", "September", "October", "November", "December"];
const days = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];

const formattedDate = computed(() => {
    const d = new Date;
    return `${days[d.getDay()]} ${d.getDate()} ${months[d.getMonth()]} ${d.getFullYear()}`;
});
</script>

<template>
    <div id="bg-weather" :class="typeof weather.main != 'undefined' && weather.main.temp > 16 ? 'warm' : ''">
        <div class="row w-50 p-2">
            <div class="col-4 p-0">
                <RouterLink class="btn btn-primary" to="/">Home</RouterLink>
            </div>
            <div class="col p-0 search-box">
                <input 
                type="text" 
                class="search-bar" 
                placeholder="Search..."
                v-model="query"
                @keypress="fetchWeather">
            </div>
        </div>

        <div class="weather-wrap" v-if="typeof weather.main != 'undefined'">
            <div class="location-box">
                <div class="location">{{ weather.name }}, {{ weather.sys.country }}</div>
                <div class="date">{{ formattedDate }}</div>
            </div>
            <div class="weather-box">
                <div class="temp">{{ Math.round(weather.main.temp) }}°C</div>
                <div class="weather">{{ weather.weather[0].main }}</div>
            </div>
        </div>
    </div>
</template>