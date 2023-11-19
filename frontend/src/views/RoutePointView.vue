<script setup lang="ts">

import { ref, computed } from "vue";
import axios from "axios";
import draggable from "vuedraggable"
import { useRoute, useRouter } from 'vue-router';
const navRoute = useRoute();
const router = useRouter();
type routePointType = {
    description: string | null,
    location: {
        id: number,
        name: string,
        description: string,
        point: {
            id: number,
            x: string,
            y: string
        }
    }
}
const list = ref<routePointType[]>([])
const model = ref({
    id: null,
    name: "",
    description: ""
});
const selectLocation = ref<{
    locationId: any,
    description: string
}>({
    locationId: null,
    description: ""
});
const locations = ref([])

const route = computed(() => {
    return `https://yandex.ru/map-widget/v1/?rtext=${list.value.map(i => `${i.location.point.x}%2C${i.location.point.y}`).join('~')}`;
})

const loadData = async () => {
    if (navRoute.query.id) {
        const routeData = (await axios.get(`/Route/Get?id=${navRoute.query.id}`)).data;
        model.value = routeData;
        list.value = routeData.routePointDto;
    }

    locations.value = (await axios.post('api/Location/List')).data
}

const addLocationToRoute = async () => {
    const location = (await axios.get(`api/Location/GetLocation/${selectLocation.value.locationId}`)).data;
    list.value.push({
        description: selectLocation.value.description,
        location: {
            name: location.name,
            description: location.description,
            id: location.Id,
            point: {
                id: location.point.id,
                x: location.point.x,
                y: location.point.y,
            }
        }
    })
    selectLocation.value = {
        locationId: null,
        description: ""
    }
}

const removeLocation = (locationItem) => {
    console.log('👖', locationItem)
    list.value = list.value.filter(x => x.id != locationItem.id)
}

const doSave = async () => {
    var res = (await axios.put('/Route/UpdateRoute', {
        Id: model.value.id,
        Name: model.value.name,
        Description: model.value.description,
        RoutePointDto: list.value.map((x) => {
            return {
                description: x.description,
                location: {
                    name: x.location.name,
                    description: x.location.description,
                    id: x.location.id,
                    point: {
                        id: x.location.point.id,
                        x: x.location.point.x,
                        y: x.location.point.y,
                    }
                }
            }
        })
    })).data;
    model.value.id = res.id;
}

loadData();
</script>

<template>
    <div class="route-block">
        <div class="route-points">
            <div class="container my-5">
                <iframe :src="route" width="100%" height="300px" frameborder="1" allowfullscreen="true"
                    style="position: relative"></iframe>
                <v-text-field placeholder="название" bg-color="white" variant="solo" v-model="model.name"></v-text-field>
                <v-textarea placeholder="описание" bg-color="white" variant="solo" v-model="model.description"></v-textarea>
                <div class="mx-auto new-point-select row">
                    <div class="row mb-3">
                        <v-select class="col-10" bg-color="white" label="Локация" variant="solo" :items="locations"
                            item-title="name" item-value="id" v-model="selectLocation.locationId">
                            <template v-slot:item="{ props, item }">
                                <v-list-item v-bind="props" :subtitle="item.raw.description" variant="solo"></v-list-item>
                            </template>
                        </v-select>
                        <v-btn height="55" class="col-2" @click="addLocationToRoute">добавить</v-btn>
                        <v-textarea class="col-12" label="описание" no-resize bg-color="white" variant="solo" auto-grow
                            shaped :hide-details="true" v-model="selectLocation.description">
                        </v-textarea>

                    </div>
                    <div class="row ml-1">
                        <v-btn :href="route" class="col-6 mr-9">Построить маршрут</v-btn>
                        <v-btn class="col-5" @click="doSave">Сохранить</v-btn>
                    </div>
                    <draggable v-model="list" item-key="id" class="list-group" ghost-class="ghost">
                        <template #item="{ element }">
                            <div class="row mt-3">
                                <v-card :title="element.location.name" class="col-6 mr-9"
                                    :text="element.location.description">
                                    <template #actions>
                                        <v-btn variant="tonal" @click="removeLocation(element)">удалить</v-btn>
                                        <v-btn variant="tonal">открыть локацию</v-btn>
                                    </template>
                                </v-card>
                                <v-textarea class="col-5" label="описание" no-resize bg-color="white" variant="solo"
                                    auto-grow shaped :hide-details="true" v-model="element.description">
                                </v-textarea>
                            </div>
                        </template>
                    </draggable>
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped lang="scss">
.route-block {
    background:
        radial-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.7)),
        url("@/assets/imgs/test.png") !important;
    overflow-y: hidden;
    height: 100vh;
    padding-top: 3em;
    z-index: 9;
}

.route-points {
    width: 100%;
    overflow-y: auto;
    max-height: 100vh;
}

.new-point-select {
    width: 40rem;
}

.ghost {
    opacity: 0.5;
    background: #c8ebfb;
}

.not-draggable {
    cursor: no-drop;
}
</style>