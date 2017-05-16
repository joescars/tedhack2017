module.exports = function(context, mySbMsg) {
    
    context.log('ServiceBus queue trigger function processed message: ', mySbMsg);

    context.bindings.profileDoc = mySbMsg;   

    context.done();
};