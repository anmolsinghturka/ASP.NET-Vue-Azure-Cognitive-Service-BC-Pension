<!-- eslint-disable vue/no-mutating-props -->
<template>
  <card>
   <div class="row">
      <div class="col-6"><h5 slot="header" class="title">Edit Profile</h5></div>
      <div class="col-6"><h5 slot="header" class="title">Confidence Score - </h5></div>
    </div>

    <div class="row">
      <div class="col-md-5 pr-md-1">
        <base-input
          label="PERSON ID"
          placeholder="Person ID"
          v-model="persionId"
        >
        </base-input>
      </div>

      <div class="col-md-3 px-md-1">
        <base-input
          label="FIRST NAME"
          placeholder="Username"
          v-model="firstName"
        >
        </base-input>
      </div>

      <div class="col-md-4 pl-md-1">
        <base-input
          label="LAST NAME"
          type="email"
          v-model="lastName"
        >
        </base-input>
      </div>
    </div>
    
    <div class="row">
      <div class="col-md-6 pr-md-1">
        <base-input
          label="Email"
          v-model="EMAIL"
          placeholder="First Name"
        >
        </base-input>
      </div>
      <div class="col-md-6 pl-md-1">
        <base-input
          label="Account No."
          v-model="accountNo"
          placeholder="Last Name"
        >
        </base-input>
      </div>
    </div>
    <div class="row">
      <div class="col-md-12">
        <base-input
          label="Address"
          v-model="address"
          placeholder="Home Address"
        >
        </base-input>
      </div>
    </div>
    <div class="row">
      <div class="col-md-4 pr-md-1">
        <base-input label="City" v-model="CITY" placeholder="City">
        </base-input>
      </div>
      <div class="col-md-4 px-md-1">
        <base-input
          label="Home Phone"
          v-model="homePhone"
          placeholder="Country"
        >
        </base-input>
      </div>
      <div class="col-md-4 pl-md-1">
        <base-input 
          label="Postal Code" 
          placeholder="Postal Code"
          v-model="postalcode"
        > 
        </base-input>
      </div>
    </div>
    <div class="row">
      <div class="col-md-8">
        <base-input>
          <label>About Me</label>
          <textarea
            rows="4"
            cols="80"
            class="form-control"
            placeholder="Here can be your description"
            v-model="INITIALS"
          >
          </textarea>
        </base-input>
      </div>
    </div>
    <base-button slot="footer" type="primary" fill>Save</base-button>
  </card>
</template>
<script>
    import { usePersonStore } from '@/stores/person'

    export default {
        props: {
            model: {
                type: Object,
                default: () => ({})
            }
        }
    }
</script>
<style></style>
