<script setup>
import { ref } from 'vue';


const calculatorValue = ref('');
const previousCalculatorValue = ref('');
const operator = ref(null);
const calculatorElements = ['C', '*', '/', '-', 7, 8, 9, '+', 4, 5, 6, '%', 1, 2, 3, '=', 0, '.'];

const action = (n) => {

    //lấy value
    if (!isNaN(n) || n === '.') {
        calculatorValue.value += n + '';
    }

    if (n === 'C') {
        calculatorValue.value = '';
    }

    if (n === '%') {
        calculatorValue.value = calculatorValue.value / 100 + '';
    }

    if (['/', '*', '+', '-'].includes(n)) {
        operator.value = n;
        previousCalculatorValue.value = calculatorValue.value;
        calculatorValue.value = '';
    }

    if (n === '=') {
        calculatorValue.value = eval(
            previousCalculatorValue.value + operator.value + calculatorValue.value
        );
        previousCalculatorValue.value = '';
        operator.value = null;
    };
}

</script>

<template>
    <div class="bg-dark d-flex vh-100">
        <div class="home p-0">
            <RouterLink class="btn btn-primary" to="/">Home</RouterLink>
        </div>
        <div class=" calculator">
            <div class="screen m-1">
                <input type="text" class="screen-input" readonly placeholder="0" v-model="calculatorValue">
            </div>
            <div class="row g-0">
                <div class="col-3" v-for="n in calculatorElements" :key="n">
                    <div class="lead m-1 py-3 text-center bg-lead"
                        :class="{ 'bg-custom': ['C', '*', '/', '-', '+', '%', '='].includes(n) }" @click="action(n)">
                        {{ n }}
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>