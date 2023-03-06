<template>
    <card type="user">
        <div slot="footer" class="button-container">
            <div class="row">
                <div class="col-lg-8 ml-auto mr-auto">
                    <div class="row">
                        <div class="col-md-12">
                            <h5 slot="header" class="title">Upload Form</h5>


                            <div class="text-center">
                                <div style="text-align: center;">
                                    <input type="file"
                                           id="uploadForm"
                                           name="uploadForm"
                                           ref="fileInput"
                                           class="form-control"
                                           @change="onFileSelected">
                                </div>
                            </div>

                            <base-button type="primary" block @click="uploadFile">
                                Submit to Azure
                            </base-button>

                            <base-input
                               label="Address"
                               v-model="MESSAGE"
                               placeholder="Home Address"
                            >
                            </base-input>



 
                            <div v-if="message" class="message">
                                <pre>{{ message }}</pre>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </card>
</template>

<script>
    import NotificationTemplate from "@/pages/Notifications/NotificationTemplate.vue";
    import { usePersonStore } from '@/stores/person';
    import { ref } from 'vue';

    export default {
        components: {},
        data() {
            return {
                type: ["", "info", "success", "warning", "danger"],
                notifications: {
                    topCenter: false,
                },
                file: null,
                message: null
            };
        },
        methods: {
            showNotification(verticalAlign, horizontalAlign) {
                const color = Math.floor(Math.random() * 4 + 1);
                this.$notify({
                    component: NotificationTemplate,
                    icon: "tim-icons icon-bell-55",
                    horizontalAlign: horizontalAlign,
                    verticalAlign: verticalAlign,
                    type: this.type[color],
                    timeout: 0,
                });
            },
            onFileSelected(event) {
                this.file = event.target.files[0];
            },
            async uploadFile() {
            const formData = new FormData();
            formData.append("file", this.file);
            try {
                const response = await fetch("https://localhost:5002/weatherforecast/upload", {
                    method: "POST",
                    body: formData
                });
            
                const data = await response.json();
                console.log(data);
                this.message = data;

                // Obtain the store instance
                const personStore = usePersonStore();
                
                // Update Pinia store state with matching keys from POST response
                const keyValuePairs = data['keyValuePairs'];
                const relevantKeys = ["EMAIL", "INITIALS", CITY];
                for (let i = 0; i < keyValuePairs.length; i++) {
                    const key = keyValuePairs[i].key;
                    const value = keyValuePairs[i].value;
                    // Filter closely related keys
                    if (relevantKeys.includes(key)) {
                        personStore[key] = value;
                    }
                }
                // Update MESSAGE field in store
                personStore.setMessage("Anmol Singh Testing");

                // this.message = data;
                console.log("After pinia state");
                this.showNotification("top-center", "right");
            } catch (error) {
                console.error(error);
                this.$notify({
                    title: "Error",
                    message: "An error occurred while uploading the file. ANMOL SINGH",
                    type: "danger",
                    position: "top-center",
                    duration: 3000,
                });
            }
        },
    },
      setup() {
        const userPersonStore = usePersonStore();
        const MESSAGE = ref(userPersonStore.MESSAGE);
        const setMessage = (MESSAGE) => {
            userPersonStore.setMessage(MESSAGE);
        };
        return {
            setMessage
        };
    }
        
    };
</script>

