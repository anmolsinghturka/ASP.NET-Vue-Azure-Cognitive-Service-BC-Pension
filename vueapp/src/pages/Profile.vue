<template>
    <div class="row">
        <div class="col-md-4">
            <user-card :user="user" @data-updated="model = $event"></user-card>
        </div>
        <div class="col-md-8">
            <edit-profile-form :model="formData"></edit-profile-form>
        </div>
    </div>
</template>

<script>
    import EditProfileForm from './Profile/EditProfileForm';
    import UserCard from './Profile/UserCard'
    export default {
        components: {
            EditProfileForm,
            UserCard
        },
        data() {
            return {
                formData: {
                    personId: '',
                    firstName: '',
                    lastName: '',
                    email: '',
                    address: '',
                    city: '',
                    postalcode: '',
                    accountNo: '',
                    initials: '',
                    homePhone: ''
                }
            }
        }
    };
</script>
