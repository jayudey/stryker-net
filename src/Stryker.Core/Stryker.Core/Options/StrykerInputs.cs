using System.IO.Abstractions;
using Microsoft.Extensions.Logging;
using Stryker.Core.Logging;
using Stryker.Core.Options.Inputs;

namespace Stryker.Core.Options
{
    public class StrykerInputs
    {
        private StrykerOptions _strykerOptionsCache;
        private readonly ILogger _logger;
        private readonly IFileSystem _fileSystem;

        public StrykerInputs(ILogger logger = null, IFileSystem fileSystem = null)
        {
            _fileSystem = fileSystem ?? new FileSystem();
            _logger = logger ?? ApplicationLogging.LoggerFactory.CreateLogger<StrykerInputs>();
        }

        public DevModeInput DevModeInput { get; init; }
        public BasePathInput BasePathInput { get; init; }
        public OutputPathInput OutputPathInput { get; init; }
        public SolutionPathInput SolutionPathInput { get; init; }
        public VerbosityInput VerbosityInput { get; init; }
        public LogToFileInput LogToFileInput { get; init; }
        public MutationLevelInput MutationLevelInput { get; init; }
        public ThresholdBreakInput ThresholdBreakInput { get; init; }
        public ThresholdHighInput ThresholdHighInput { get; init; }
        public ThresholdLowInput ThresholdLowInput { get; init; }
        public AdditionalTimeoutMsInput AdditionalTimeoutMsInput { get; init; }
        public LanguageVersionInput LanguageVersionInput { get; init; }
        public ConcurrencyInput ConcurrencyInput { get; init; }
        public ProjectUnderTestNameInput ProjectUnderTestNameInput { get; init; }
        public TestProjectsInput TestProjectsInput { get; init; }
        public WithBaselineInput WithBaselineInput { get; init; }
        public ReportersInput ReportersInput { get; init; }
        public BaselineProviderInput BaselineProviderInput { get; init; }
        public AzureFileStorageUrlInput AzureFileStorageUrlInput { get; init; }
        public AzureFileStorageSasInput AzureFileStorageSasInput { get; init; }
        public DashboardUrlInput DashboardUrlInput { get; init; }
        public DashboardApiKeyInput DashboardApiKeyInput { get; init; }
        public ProjectNameInput ProjectNameInput { get; init; }
        public SinceInput SinceInput { get; init; }
        public SinceTargetInput SinceTargetInput { get; init; }
        public DiffIgnoreFilePatternsInput DiffIgnoreFilePatternsInput { get; init; }
        public FallbackVersionInput FallbackVersionInput { get; init; }
        public ProjectVersionInput ProjectVersionInput { get; init; }
        public ModuleNameInput ModuleNameInput { get; init; }
        public MutateInput MutateInput { get; init; }
        public IgnoreMethodsInput IgnoredMethodsInput { get; init; }
        public IgnoreMutationsInput ExcludedMutationsInput { get; init; }
        public CoverageAnalysisInput CoverageAnalysisInput { get; init; }
        public DisableBailInput DisableBailInput { get; set; }
        public DisableMixMutantsInput DisableMixMutantsInput { get; set; }

        public StrykerOptions ValidateAll()
        {
            var reporters = ReportersInput.Validate();
            var baselineProvider = BaselineProviderInput.Validate(reporters);
            var sinceEnabled = SinceInput.Validate(WithBaselineInput.SuppliedInput);

            _strykerOptionsCache ??= new StrykerOptions()
            {
                Concurrency = ConcurrencyInput.Validate(_logger),
                MutationLevel = MutationLevelInput.Validate(),
                DevMode = DevModeInput.Validate(),
                SolutionPath = SolutionPathInput.Validate(_fileSystem),
                LogOptions = new LogOptions
                {
                    LogLevel = VerbosityInput.Validate(),
                    LogToFile = LogToFileInput.Validate(OutputPathInput.SuppliedInput)
                },
                Thresholds = new Thresholds
                {
                    High = ThresholdHighInput.Validate(ThresholdLowInput.SuppliedInput),
                    Low = ThresholdLowInput.Validate(ThresholdBreakInput.SuppliedInput, ThresholdHighInput.SuppliedInput),
                    Break = ThresholdBreakInput.Validate(ThresholdLowInput.SuppliedInput),
                },
                Reporters = reporters,
                ProjectUnderTestName = ProjectUnderTestNameInput.Validate(),
                AdditionalTimeoutMS = AdditionalTimeoutMsInput.Validate(),
                ExcludedMutations = ExcludedMutationsInput.Validate(),
                IgnoredMethods = IgnoredMethodsInput.Validate(),
                Mutate = MutateInput.Validate(),
                LanguageVersion = LanguageVersionInput.Validate(),
                OptimizationMode = CoverageAnalysisInput.Validate() & DisableBailInput.Validate() & DisableMixMutantsInput.Validate(),
                TestProjects = TestProjectsInput.Validate(),
                DashboardUrl = DashboardUrlInput.Validate(),
                DashboardApiKey = DashboardApiKeyInput.Validate(WithBaselineInput.SuppliedInput),
                ProjectName = ProjectNameInput.Validate(WithBaselineInput.SuppliedInput),
                ModuleName = ModuleNameInput.Validate(),
                ProjectVersion = ProjectVersionInput.Validate(FallbackVersionInput.SuppliedInput, reporters, WithBaselineInput.SuppliedInput),
                DiffIgnoreFilePatterns = DiffIgnoreFilePatternsInput.Validate(),
                AzureFileStorageSas = AzureFileStorageSasInput.Validate(baselineProvider),
                AzureFileStorageUrl = AzureFileStorageUrlInput.Validate(baselineProvider),
                WithBaseline = WithBaselineInput.Validate(),
                BaselineProvider = baselineProvider,
                FallbackVersion = FallbackVersionInput.Validate(SinceTargetInput.SuppliedInput, WithBaselineInput.SuppliedInput),
                Since = sinceEnabled,
                SinceTarget = SinceTargetInput.Validate(sinceEnabled),
                BasePath = BasePathInput.Validate(_fileSystem),
                OutputPath = OutputPathInput.Validate(_logger, _fileSystem, BasePathInput.SuppliedInput)
            };
            return _strykerOptionsCache;
        }
    }
}
