//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by jni4net. See http://jni4net.sourceforge.net/ 
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mojomysql {
    
    
    #region Component Designer generated code 
    [global::net.sf.jni4net.attributes.JavaClassAttribute()]
    public partial class StackTraceUtil : global::java.lang.Object {
        
        internal new static global::java.lang.Class staticClass;
        
        internal static global::net.sf.jni4net.jni.MethodId j4n_getStackTrace0;
        
        internal static global::net.sf.jni4net.jni.MethodId j4n_getCustomStackTrace1;
        
        internal static global::net.sf.jni4net.jni.MethodId j4n__ctorStackTraceUtil2;
        
        [global::net.sf.jni4net.attributes.JavaMethodAttribute("()V")]
        public StackTraceUtil() : 
                base(((global::net.sf.jni4net.jni.JNIEnv)(null))) {
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.ThreadEnv;
            using(new global::net.sf.jni4net.jni.LocalFrame(@__env, 10)){
            @__env.NewObject(global::mojomysql.StackTraceUtil.staticClass, global::mojomysql.StackTraceUtil.j4n__ctorStackTraceUtil2, this);
            }
        }
        
        protected StackTraceUtil(global::net.sf.jni4net.jni.JNIEnv @__env) : 
                base(@__env) {
        }
        
        public static global::java.lang.Class _class {
            get {
                return global::mojomysql.StackTraceUtil.staticClass;
            }
        }
        
        private static void InitJNI(global::net.sf.jni4net.jni.JNIEnv @__env, java.lang.Class @__class) {
            global::mojomysql.StackTraceUtil.staticClass = @__class;
            global::mojomysql.StackTraceUtil.j4n_getStackTrace0 = @__env.GetStaticMethodID(global::mojomysql.StackTraceUtil.staticClass, "getStackTrace", "(Ljava/lang/Throwable;)Ljava/lang/String;");
            global::mojomysql.StackTraceUtil.j4n_getCustomStackTrace1 = @__env.GetStaticMethodID(global::mojomysql.StackTraceUtil.staticClass, "getCustomStackTrace", "(Ljava/lang/Throwable;)Ljava/lang/String;");
            global::mojomysql.StackTraceUtil.j4n__ctorStackTraceUtil2 = @__env.GetMethodID(global::mojomysql.StackTraceUtil.staticClass, "<init>", "()V");
        }
        
        [global::net.sf.jni4net.attributes.JavaMethodAttribute("(Ljava/lang/Throwable;)Ljava/lang/String;")]
        public static global::java.lang.String getStackTrace(global::java.lang.Throwable par0) {
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.ThreadEnv;
            using(new global::net.sf.jni4net.jni.LocalFrame(@__env, 12)){
            return global::net.sf.jni4net.utils.Convertor.StrongJ2CpString(@__env, @__env.CallStaticObjectMethodPtr(global::mojomysql.StackTraceUtil.staticClass, global::mojomysql.StackTraceUtil.j4n_getStackTrace0, global::net.sf.jni4net.utils.Convertor.ParFullC2J<global::java.lang.Throwable>(@__env, par0)));
            }
        }
        
        [global::net.sf.jni4net.attributes.JavaMethodAttribute("(Ljava/lang/Throwable;)Ljava/lang/String;")]
        public static global::java.lang.String getCustomStackTrace(global::java.lang.Throwable par0) {
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.ThreadEnv;
            using(new global::net.sf.jni4net.jni.LocalFrame(@__env, 12)){
            return global::net.sf.jni4net.utils.Convertor.StrongJ2CpString(@__env, @__env.CallStaticObjectMethodPtr(global::mojomysql.StackTraceUtil.staticClass, global::mojomysql.StackTraceUtil.j4n_getCustomStackTrace1, global::net.sf.jni4net.utils.Convertor.ParFullC2J<global::java.lang.Throwable>(@__env, par0)));
            }
        }
        
        new internal sealed class ContructionHelper : global::net.sf.jni4net.utils.IConstructionHelper {
            
            public global::net.sf.jni4net.jni.IJvmProxy CreateProxy(global::net.sf.jni4net.jni.JNIEnv @__env) {
                return new global::mojomysql.StackTraceUtil(@__env);
            }
        }
    }
    #endregion
}
