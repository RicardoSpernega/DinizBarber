import { ScaledSheet } from "react-native-size-matters";
import { Dimensions, StyleSheet } from 'react-native'
import { COLOR } from '../../config/styles';

export const style = ScaledSheet.create({    
    lineMares:{
    },
    label:{
        color: COLOR.MAIN,
        width: '300@vs',
        marginRight: 'auto',
        marginLeft: 'auto',
        borderColor: 'transparent'
    },
    title:{
        fontSize: '24@s', 
        color: COLOR.BLACK,
        fontWeight: 'bold',
        marginLeft: '10@s',
        marginVertical: '20@vs'
    },
    boxClimatempo:{        
        flexDirection: 'row', 
        alignItems: 'center',
        padding: '20@s',
        marginTop: '50@vs'
    },
    card:{
        flexDirection: 'row',
        padding: '10@s',
        borderRadius: 10,
        alignItems: 'center',
        justifyContent: 'space-between',
        height: '60@vs'
    },
    cardBox:{
        marginTop: 10, 
        borderRadius: 20,     
        elevation: 7,
        marginHorizontal: '20@s',
    },
    numberTemp:{
        color: COLOR.LIGHT,
        fontWeight: 'bold',
        justifyContent: 'center',
    },
    divider:{
        borderLeftWidth: 1,
        borderColor: COLOR.LIGHT,
        marginHorizontal: '20@s',
    },
    smallText: {
        fontSize: 11,
    },
    titleCard:{
        color: COLOR.LIGHT,
        fontWeight: 'bold',
        width: '100@s',
        textAlign: 'center'
    },
    date:{
        color: COLOR.LIGHT,
        fontSize: '12@s',
        textAlign: 'center'
    },
    dividerHorizontal:{        
        borderLeftWidth: 1,
        borderColor: COLOR.LIGHT,
        marginHorizontal: '10@s'
    },
    iconCard:{
        opacity: 0.6,
        color: COLOR.LIGHT
    },
    iconTitle:{
        color: COLOR.LIGHT,
        backgroundColor: COLOR.MAIN,
        padding: 7,
        borderRadius: 50,
        width: '45@s',
        height: '50@vs',
        textAlign: 'center'
    },
});

export const StylesAccordion = ScaledSheet.create({
    upDownIcon: {
        color: COLOR.LIGHT,
        fontSize: '20@s',
        paddingVertical: '8@vs',
        marginLeft: '-120@s',
        marginRight: '20@s'
    },
    viewInfo: {
        flexDirection: 'row',
        paddingBottom: '5@vs',
        alignContent: 'center',
        marginVertical: '10@vs',
        marginRight: '20@s',
        justifyContent: 'flex-end',
    },
    itemTitle: {
        fontSize: '10@s',
        marginTop: '5@vs',
    },
    iconTitle:{
        color: COLOR.LIGHT,
        backgroundColor: COLOR.MAIN,
        padding: 4,
        borderRadius: 50,
        width: '40@s',
        height: '45@vs',
        textAlign: 'center'
    },
    itemInfo:{
        color: COLOR.LIGHT,
        fontWeight: 'bold',
    }
});