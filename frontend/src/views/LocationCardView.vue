<script setup lang="ts">
import { ref, computed } from 'vue'
import { useRoute, useRouter } from 'vue-router'
const navRoute = useRoute()
const router = useRouter()
import axios from 'axios'
const model = ref<{
    id: 0 | null
    name: string
    description: string
    workTimeStart: string
    workTimeEnd: string
    locationType: number
    point: {
        id: number | null
        x: string
        y: string
    },
    href: string
}>({
    id: 0,
    name: '',
    description: '',
    workTimeStart: '',
    workTimeEnd: '',
    locationType: 0,
    point: {
        id: 0,
        x: '',
        y: ''
    },
    href: ''
})

const doSave = () => {
    axios.put('api/Location/CreateLocation', model.value)
}

const loadData = async () => {
    if (navRoute.query.id) {
        model.value = (await axios.get(`/api/Location/GetLocation/${navRoute.query.id}`)).data
    }
}
loadData()
</script>

<template>
    <div>
        <div class="image-block d-flex d-inline-flex">
            <img src="@/assets/imgs/building.png" class="image-style" />
            <div class="ya-card">
                <iframe :src="model.href" width="100%" height="100%" frameborder="1" allowfullscreen="true"
                    style="position: relative"></iframe>
            </div>
        </div>
        <div>
            <div class="container mt-3">
                <v-text-field placeholder="название" v-model="model.name" />
                <v-textarea placeholder="описание" v-model="model.description" />
                <div class="row">
                    <v-text-field placeholder="x" class="col" v-model="model.point.x" />
                    <v-text-field placeholder="y" class="col" v-model="model.point.y" />
                </div>
                <div class="row pr-3">
                    <v-text-field placeholder="ссылка" class="col-11" v-model="model.href"></v-text-field>
                    <v-btn height="55" class="col-1">Перейти</v-btn>
                </div>
                <v-btn @click="doSave">Сохранить</v-btn>
            </div>
        </div>
    </div>
</template>

<style lang="scss" scoped>
.image-block {
    padding-top: 70px;
    width: 100vw;
    height: 50vh;
    background: radial-gradient(rgba(161, 141, 141, 0), rgba(161, 141, 141, 0.1));
}

.ya-card {
    position: relative;
    overflow: hidden;
    padding: 0;
    margin: 0;
    width: 50vw !important;
}

.image-block img {
    width: 50vw;
    height: auto;
    padding: 0;
    margin: 0;
}
</style>
