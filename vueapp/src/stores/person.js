import { defineStore } from 'pinia'

export const usePersonStore = defineStore({
    id: 'person',
    state: () => ({
        personId: '',
        firstName: '',
        lastName: '',
        EMAIL: '',
        address: '',
        CITY: '',
        postalcode: '',
        accountNo: '',
        INITIALS: '',
        homePhone: '',
        MESSAGE: ""
    }),
    actions: {
        setPersonInfo(info) {
            this.personId = info.personId
            this.firstName = info.firstName
            this.lastName = info.lastName
            this.EMAIL = info.EMAIL
            this.address = info.address
            this.CITY = info.CITY
            this.postalcode = info.postalcode
            this.accountNo = info.accountNo
            this.INITIALS = info.INITIALS
            this.homePhone = info.homePhone
        },
        setEmail(email) {
            this.EMAIL = email
        },
        setInitials(initials) {
            this.INITIALS = initials
        },
        setCity(city) {
            this.CITY = city
        },
        setMessage(message) {
            this.MESSAGE = message
        },
        clearPersonInfo() {
            this.personId = ''
            this.firstName = ''
            this.lastName = ''
            this.EMAIL = ''
            this.address = ''
            this.CITY = ''
            this.postalcode = ''
            this.accountNo = ''
            this.INITIALS = ''
            this.homePhone = ''
        },
    },
})
