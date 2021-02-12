import moment from 'moment';

const dateFormatter = (date) => {
    return moment(date).format('DD/MM/YYYY HH:mm');
}

export default dateFormatter;
